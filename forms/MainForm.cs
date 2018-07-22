using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JPPSVN.jpp;
using JPPSVN;
using JPPSVN.Properties;
using JPPSVN.tasks;
using SharpSvn;

namespace JPPSVN.forms {
	public partial class MainForm : Form {
		private PathBuilder pathBuilder;
		private IntelliJIDEA intelliJIDEA;
		private TaskDispatcher<StatusBackgroundWorker> taskDispatcher;
		private RepositoryActions repositoryActions;
		private SettingsData currentSettings = null;
		private ClearnameResolver clearNames = null;
		private bool changingUser = false;

      #region Properties

      public string Revision { get => revisionTextBox.Text; set => revisionTextBox.Text = value; }

		public string User {
			get => userTextBox.Text;
			set {
				changingUser = true;
            userTextBox.Text = value;
				changingUser = false;
         }
		}

		public string Project { get => projectTextBox.Text; set => projectTextBox.Text = value; }
		
		public string OutputFolder { get; set; }

		public string IDEAPath { get; set; }

		public string UserName {
			get => nameTextBox.Text;
			set {
				changingUser = true;
				nameTextBox.Text = value;
				changingUser = false;
         }
		}

		private bool HasUser => User != null && User.Length == 7;

		private bool HasProject => !string.IsNullOrWhiteSpace(Project);
		
      private ClearnameResolver ClearNames {
	      get => clearNames;
	      set {
				clearNames = value;
				if (clearNames == null) return;

		      var autocomplete = new AutoCompleteStringCollection();
		      autocomplete.AddRange(clearNames.GetIds().ToArray());
		      userTextBox.AutoCompleteCustomSource = autocomplete;

		      autocomplete = new AutoCompleteStringCollection();
		      autocomplete.AddRange(clearNames.GetNames().ToArray());
		      nameTextBox.AutoCompleteCustomSource = autocomplete;
	      }
		}
      #endregion

      public MainForm() {
			InitializeComponent();
		}

		private void LoadGUIFromSettings(Settings settings) {
			Revision = settings.LastRevision;
			User = settings.LastUser;
			Project = settings.LastProject;
		}

		private void UpdateProjectsAutocomplete(string[] projects) {
			var autocomplete = new AutoCompleteStringCollection();
			autocomplete.AddRange(projects);
			projectTextBox.AutoCompleteCustomSource = autocomplete;
		}

      private void UpdateUserName() {
			if (changingUser || ClearNames == null)
				return;
			string text = User;
			if (text.Length == 0)
				return;
			if (ClearNames.ResolveName(text, out var s) && s.Count == 1) {
				UserName = s[0];
			}
		}

		private void UpdateUser() {
			if (changingUser || ClearNames == null)
				return;
			string text = UserName;
			if (text.Length == 0)
				return;
			if (ClearNames.ResolveID(text, out var s) && s.Count == 1) {
				User = s[0];
			}
		}

		private void HandleBackgroundException(Exception e) {
			string message;
			if (e is SvnSystemException svne) {
				Exception inner = svne.InnerException;
				message = inner != null ? inner.Message : svne.Message;
			} else message = e.Message;

			MessageBox.Show(this, message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

      private void ReloadAsync(string repositoryURL) {
			var worker = repositoryActions.StartupUpdate(repositoryURL);
			worker.RunWorkerCompleted += (o, ev) => {
				if (ev.Error == null) {
					ClearNames = worker.ClearnameResolver;
					UpdateProjectsAutocomplete(worker.Projects);

					UpdateUserName();
					UpdateUser();
				} else
					HandleBackgroundException(ev.Error);
			};
			taskDispatcher.Run(worker);
      }
		
		private void UpdateIntelliJPath(bool autoFind, string path) {
			IDEAPath = IntelliJIDEA.FindExe(autoFind, path);
			intelliJIDEA = IntelliJIDEA.IsValidIDEA(IDEAPath) ? new IntelliJIDEA(IDEAPath) : null;
		}

      private void LoadFromValidatedSettings(SettingsData settings) {
	      currentSettings = settings;
			
         OutputFolder = settings.OutputFolder;

			pathBuilder = new PathBuilder(settings.RepositoryFolder);

			repositoryActions.PathBuilder = pathBuilder;

         UpdateIntelliJPath(settings.AutoFindIDEA, settings.IDEAPath);
      }

		private bool LoadVarsFromSettings(SettingsData settings) {
			if (string.IsNullOrWhiteSpace(settings.RepositoryFolder) || string.IsNullOrWhiteSpace(settings.OutputFolder) || string.IsNullOrWhiteSpace(settings.RepositoryURL))
				return false;

			LoadFromValidatedSettings(settings);

			return true;
		}
		
      private void LoadChangedSettings(SettingsData settings, bool shouldUpdateIfNecessary) {
			bool repositoryFolderChanged = currentSettings.RepositoryFolder != settings.RepositoryFolder;
			bool repositoryURLChanged = currentSettings.RepositoryURL != settings.RepositoryURL;

         bool needUpdate = shouldUpdateIfNecessary && (repositoryFolderChanged | repositoryURLChanged);

			if (repositoryURLChanged) {
				if(!repositoryFolderChanged) {
					DialogResult result = MessageBox.Show("Die Repository-URL wurde geändert. Soll der Repositoryordner geleert werden?", "Hinweis", MessageBoxButtons.YesNoCancel);
					switch(result) {
						case DialogResult.Cancel:
							return;
						case DialogResult.Yes:
							DirectoryUtil.DeleteDirectory(currentSettings.RepositoryFolder);
                     break;
						case DialogResult.No:
							break;
					}
				} 
         }
			
			LoadFromValidatedSettings(settings);

         if(needUpdate)
				ReloadAsync(settings.RepositoryURL);
      }

		private SettingsData OpenSettings() {
			SettingsData data = new SettingsData(currentSettings);
			SettingsForm settingsForm = new SettingsForm(data);
			return settingsForm.ShowDialog() == DialogResult.OK ? data : null;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			repositoryActions = new RepositoryActions(toolStripStatusLabel);
			taskDispatcher = new TaskDispatcher<StatusBackgroundWorker>();

			SettingsData settings = new SettingsData(Settings.Default);

			LoadGUIFromSettings(Settings.Default);

			if(!LoadVarsFromSettings(settings)) {
				settings = OpenSettings();
				if(settings == null) {
					Close();
					return;
				}

				LoadChangedSettings(settings, false);
			}

			ReloadAsync(settings.RepositoryURL);
		}
		
		private void SaveLast(Settings settings) {
			settings.LastRevision = Revision;
			settings.LastUser = User;
			settings.LastProject = Project;
		}

      protected override void OnClosing(CancelEventArgs e) {
			base.OnClosing(e);

			Properties.Settings settings = Properties.Settings.Default;
	      SaveLast(settings);
         currentSettings.Save(settings);
			settings.Save();

	      currentSettings = null;
			
         if (repositoryActions != null) {
				repositoryActions.Dispose();
				repositoryActions = null;
         }

	      taskDispatcher = null;
	      pathBuilder = null;

         clearNames = null;
			intelliJIDEA = null;
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
		
		#region UI Events

		private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e) {
			SettingsData settings = OpenSettings();

			if (settings != null)
				LoadChangedSettings(settings, true);
		}

		private void ordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!HasUser) return;
			string path = pathBuilder.GetUserProjects(User);
			if(Directory.Exists(path))
				Explorer.Open(path);
			else
				MessageBox.Show("Ordner von \"" + User + "\" konnte nicht gefunden werden.");
		}

		private void projektordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!HasUser || !HasProject) return;
			string path = pathBuilder.GetUserProject(User, Project);
			if(Directory.Exists(path))
				Explorer.Open(path);
			else
				MessageBox.Show("Projektordner des Projekts \"" + Project + "\" von \"" + User +
				                "\" konnte nicht gefunden werden.");
		}

		private void ordnerToolStripMenuItem2_Click(object sender, EventArgs e) {
			if(HasProject) {
				string path = pathBuilder.GetProject(Project);
				if(Directory.Exists(path))
					Explorer.Open(path);
				else
					MessageBox.Show("Projektordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.");
			}
		}

		private void updateFolder(string path, string revision) {
			StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
			task.DoWork += (o, ev) => {
				task.Status = "Aktualisiere Ordner \"" + path + "\"";
				SubversionHelper.Update(path, revision);
			};
			task.RunWorkerCompleted += (sender, args) => HandleBackgroundException(args.Error);
			taskDispatcher.Run(task);
		}

		private void updateProjektordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!taskDispatcher.IsTaskRunning && HasUser && HasProject) {
				updateFolder(pathBuilder.GetUserProject(User, Project), Revision);
			}
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
			if(taskDispatcher.IsTaskRunning || !HasProject) return;
			string path = pathBuilder.GetProject(Project);
			if(Directory.Exists(path))
				updateFolder(path, null);
			else
				MessageBox.Show(this, "Ordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.",
					"Fehler");
		}

		private void userTextBox_TextChanged(object sender, EventArgs e) {
			UpdateUserName();
		}

		private void nameTextBox_TextChanged(object sender, EventArgs e) {
			UpdateUser();
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
