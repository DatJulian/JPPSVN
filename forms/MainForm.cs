using JPPSVN.jpp;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using JPPSVN.tasks;

namespace JPPSVN {
	public class Data {
		internal string User { get; set; }
		internal string UserName { get; set; }
		internal string Project { get; set; }
		internal string Revision { get; set; }
	}

	public partial class MainForm : Form {
		private PathBuilder jppExtractor;
		private IntelliJIDEA intelliJIDEA;
		private TaskDispatcher<StatusBackgroundWorker> taskDispatcher;
		private RepositoryActions repositoryActions;

		#region Properties

		public string Revision { get => revisionTextBox.Text; set => revisionTextBox.Text = value; }

		public string User { get => userTextBox.Text; set => userTextBox.Text = value; }

		public string Project { get => projectTextBox.Text; set => projectTextBox.Text = value; }

		public string RepositoryFolder { get; set; }

		public string RepositoryURL { get; set; }

		public string OutputFolder { get; set; }

		public string IDEAPath { get; set; }

		public string UserName { get => nameLabel.Text; set => nameLabel.Text = value; }

		private bool HasUser => User != null && User.Length == 7;

		private bool HasProject => !string.IsNullOrWhiteSpace(Project);

		private ClearnameResolver ClearNames { get; set; } = ClearnameResolver.EMPTY;

      #endregion

      public MainForm() {
			InitializeComponent();
		}

		private void LoadGUIFromSettings(Properties.Settings settings) {
			Revision = settings.LastRevision;
			User = settings.LastUser;
			Project = settings.Project;
		}

		private bool LoadVarsFromSettings(Properties.Settings settings) {
			RepositoryFolder = settings.RepositoryFolder;

			//if (!Validation.Main.IsValidRepositoryFolder(RepositoryFolder))
			//return false;

			OutputFolder = settings.OutputFolder;

			RepositoryURL = settings.RepositoryURL;

			if(string.IsNullOrEmpty(OutputFolder))
				return false;

			IDEAPath = IntelliJIDEA.FindExe(settings.AutoFindIDEA, settings.IDEAPath);

			if(!IntelliJIDEA.IsValidIDEA(IDEAPath))
				return false;
			intelliJIDEA = new IntelliJIDEA(IDEAPath);

			return true;
		}

		private void SaveToSettings(Properties.Settings settings) {
			settings.LastRevision = Revision;
			settings.LastUser = User;
			settings.Project = Project;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			Properties.Settings settings = Properties.Settings.Default;
			if(!LoadVarsFromSettings(settings) && (new Settings().ShowDialog() != DialogResult.OK ||
			                                       !LoadVarsFromSettings(Properties.Settings.Default)))
				Close();

			jppExtractor = new PathBuilder(RepositoryFolder);

			LoadGUIFromSettings(settings);

			repositoryActions = new RepositoryActions(toolStripStatusLabel, RepositoryFolder);

			taskDispatcher = new TaskDispatcher<StatusBackgroundWorker>();
			var worker = repositoryActions.StartupUpdate(RepositoryURL);
			worker.RunWorkerCompleted += (o, ev) => {
				var task = (Tasks.StartupUpdateTask) ev.Result;
				ClearNames = task.ClearnameResolver;

				projectTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				projectTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
				var autocomplete = new AutoCompleteStringCollection();
				autocomplete.AddRange(task.Projects);
				projectTextBox.AutoCompleteCustomSource = autocomplete;

				if(ev.Error != null)
					HandleBackgroundException(ev.Error);
				UpdateUserName();
			};
			taskDispatcher.Run(worker);
		}

		private void UpdateUserName() {
			if(ClearNames == null)
				return;
			string text = userTextBox.Text;
			if(text.Length == 0)
				return;
			if(ClearNames.ResolveName(text, out var s)) {
				UserName = s.Count == 1 ? s[0] : "Nicht eindeutig";
			} else {
				UserName = "Unbekannt";
			}
		}

		protected override void OnClosing(CancelEventArgs e) {
			base.OnClosing(e);

			Properties.Settings settings = Properties.Settings.Default;
			SaveToSettings(settings);
			settings.Save();

			if(repositoryActions != null) {
				repositoryActions.Dispose();
				repositoryActions = null;
         }
			

			ClearNames = null;
		}

		private static StatusBackgroundWorker OpenExplorerAfter(CopyProjectTask task) {
			task.RunWorkerCompleted += (sender, e) => { Explorer.Open(task.Destination); };

			return task;
		}

		private StatusBackgroundWorker OpenIntelliJAfter(CopyProjectTask task) {
			task.RunWorkerCompleted += (sender, e) => { intelliJIDEA.Open(task.Destination); };

			return task;
		}

		public Data MakeSnapshot() {
			return new Data {
				User = User,
				UserName = UserName,
				Project = Project,
				Revision = Revision
			};
		}

		private string MakeOutputPath() {
			return Path.Combine(OutputFolder, Project, User);
		}

		private void HandleBackgroundException(Exception e) {
			MessageBox.Show(this, e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#region UI Events

		private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e) {
			if(new Settings().ShowDialog() == DialogResult.OK)
				LoadVarsFromSettings(Properties.Settings.Default);
		}

		private void ordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(HasUser) {
				string path = jppExtractor.GetUserProjects(User);
				if(Directory.Exists(path))
					Explorer.Open(path);
				else
					MessageBox.Show("Ordner von \"" + User + "\" konnte nicht gefunden werden.");
			}
		}

		private void projektordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(HasUser && HasProject) {
				string path = jppExtractor.GetUserProject(User, Project);
				if(Directory.Exists(path))
					Explorer.Open(path);
				else
					MessageBox.Show("Projektordner des Projekts \"" + Project + "\" von \"" + User +
					                "\" konnte nicht gefunden werden.");
			}
		}

		private void ordnerToolStripMenuItem2_Click(object sender, EventArgs e) {
			if(HasProject) {
				string path = jppExtractor.GetProject(Project);
				if(Directory.Exists(path))
					Explorer.Open(path);
				else
					MessageBox.Show("Projektordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.");
			}
		}

		private void erstellteOrdnerLöschenToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!taskDispatcher.IsTaskRunning && HasProject && HasUser) {
				string path = MakeOutputPath();
				StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
				task.DoWork += (o, ev) => {
					task.Status = "Lösche Ordner \"" + path + "\"";
					if(Directory.Exists(path)) DirectoryUtil.DeleteDirectory(path);
				};
				taskDispatcher.Run(task);
			}
		}

		private void updateFolder(string path, string revision) {
			StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
			task.DoWork += (o, ev) => {
				task.Status = "Aktualisiere Ordner \"" + path + "\"";
				SubversionHelper.Update(path, revision);
			};
			taskDispatcher.Run(task);
		}

		private void updateProjektordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!taskDispatcher.IsTaskRunning && HasUser && HasProject) {
				updateFolder(jppExtractor.GetUserProject(User, Project), Revision);
			}
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!taskDispatcher.IsTaskRunning && HasProject) {
				string path = jppExtractor.GetProject(Project);
				if(Directory.Exists(path))
					updateFolder(path, null);
				else
					MessageBox.Show(this, "Projektordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.",
						"Fehler");
			}
		}

		private void userTextBox_TextChanged(object sender, EventArgs e) {
			UpdateUserName();
		}

		private ProjectForm MakeProjectForm(string destination, Data data) {
			return new ProjectForm(new ProjectForm.ProjectFormArgs() {
				Data = data,
				Folder = destination,
				IntelliJ = intelliJIDEA
			});
		}

		private void HandleExecutionFinished(string destination, Data data, RunWorkerCompletedEventArgs args) {
			if(args.Error != null) {
				HandleBackgroundException(args.Error);
			} else if(!args.Cancelled)
				MakeProjectForm(destination, data).Show();
		}

		private void codeTestsToolStripMenuItem_Click(object sender, EventArgs e) {
			if(taskDispatcher.IsTaskRunning || !HasProject || !HasUser) return;
			var path = MakeOutputPath();
			var data = MakeSnapshot();
			var task = repositoryActions.CopyAllTask(data, path);
			task.RunWorkerCompleted += (s, ev) => { HandleExecutionFinished(path, data, ev); };
			taskDispatcher.Run(task);
		}

		private void codeToolStripMenuItem_Click(object sender, EventArgs e) {
			if (taskDispatcher.IsTaskRunning || !HasProject || !HasUser) return;
         var path = MakeOutputPath();
			var data = MakeSnapshot();
			var task = repositoryActions.CopyProjectTask(data, path);
			task.RunWorkerCompleted += (s, ev) => { HandleExecutionFinished(path, data, ev); };
			taskDispatcher.Run(task);
		}

		#endregion
	}
}
