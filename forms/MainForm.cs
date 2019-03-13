using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JPPSVN.jpp;
using JPPSVN.Properties;
using JPPSVN.tasks;
using SharpSvn;

namespace JPPSVN.forms {
	public partial class MainForm : Form {
		private PathBuilder pathBuilder;
		private IntelliJIDEA intelliJIDEA;
		private TaskDispatcher taskDispatcher;
		private RepositoryActions repositoryActions;
		private bool onlySrcFolderFromProject;
      private SettingsData currentSettings = null;
		private string lastSelectedProject = null;
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

		public string Project { get => projectComboBox.Text; set => projectComboBox.Text = value; }
		
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

		      UpdateAutoComplete(userTextBox, clearNames.Ids);
		      UpdateAutoComplete(nameTextBox, clearNames.Names);
	      }
		}
      #endregion

      public MainForm() {
         InitializeComponent();
	      //if(Debugger.IsAttached)
		     // Settings.Default.Reset();
      }

		private static void UpdateAutoComplete(TextBox textBox, IEnumerable<string> values) {
			var autocomplete = new AutoCompleteStringCollection();
			autocomplete.AddRange(values.ToArray());
			textBox.AutoCompleteCustomSource = autocomplete;
      }

		private void LoadGUIFromSettings(Settings settings) {
			Revision = settings.LastRevision;
			User = settings.LastUser;
			lastSelectedProject = settings.LastProject;
		}
		
      private void UpdateUserName() {
			if (changingUser || ClearNames == null)
				return;
			string text = User;
			if (text.Length != 0 && ClearNames.ResolveName(text, out var s) && s.Count == 1) {
				UserName = s[0];
			} else {
				UserName = string.Empty;
			}
      }
		
		private void UpdateUser() {
			if (changingUser || ClearNames == null)
				return;
			string text = UserName;
			if (text.Length != 0 && ClearNames.ResolveID(text, out var s) && s.Count == 1) {
				User = s[0];
			} else {
				User = string.Empty;
			}
		}

		private void ShowError(string text) {
			MessageBox.Show(this, text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

		private void HandleBackgroundException(Exception e) {
			string message;
			if (e is SvnSystemException svne) {
				Exception inner = svne.InnerException;
				message = inner != null ? inner.Message : svne.Message;
			} else message = e.Message;

			ShowError(message);
		}

      private void ReloadAsync(string repositoryURL, bool urlChanged) {
			var worker = repositoryActions.StartupUpdate(repositoryURL, urlChanged);
			worker.RunWorkerCompleted += (o, ev) => {
				if (ev.Error == null) {
					ClearNames = worker.ClearnameResolver;
					projectComboBox.Items.Clear();
               projectComboBox.Items.AddRange(worker.Projects);
					if(lastSelectedProject != null) {
						projectComboBox.SelectedItem = lastSelectedProject;
					}

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
			onlySrcFolderFromProject = settings.OnlySrcFolderFromProject;
         UpdateIntelliJPath(settings.AutoFindIDEA, settings.IDEAPath);
      }

		private bool LoadVarsFromSettings(SettingsData settings) {
			if (string.IsNullOrWhiteSpace(settings.RepositoryFolder) || string.IsNullOrWhiteSpace(settings.OutputFolder) || string.IsNullOrWhiteSpace(settings.RepositoryURL))
				return false;

			LoadFromValidatedSettings(settings);

			return true;
		}
		
      private void LoadChangedSettings(SettingsData settings, bool forceUpdate) {
	      bool needUpdate;
	      bool repositoryURLChanged;
			
         if (currentSettings != null) {
		      bool repositoryFolderChanged = currentSettings.RepositoryFolder != settings.RepositoryFolder;
		      repositoryURLChanged = currentSettings.RepositoryURL != settings.RepositoryURL;

		      needUpdate = forceUpdate || (repositoryFolderChanged || repositoryURLChanged);

		      if(repositoryURLChanged) {
			      if(!repositoryFolderChanged && Directory.Exists(currentSettings.RepositoryFolder)) {
				      DialogResult result = MessageBox.Show("Die Repository-URL wurde geändert. Soll der Repositoryordner geleert werden? (Nein könnte zu einer kaputten Repository führen)", "Hinweis", MessageBoxButtons.YesNoCancel);
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
	      } else {
		      needUpdate = true;
		      repositoryURLChanged = true;
	      }

	      LoadFromValidatedSettings(settings);

         if(needUpdate)
				ReloadAsync(settings.RepositoryURL, repositoryURLChanged);
      }

		private static SettingsData OpenSettings(SettingsData set) {
			SettingsData data = new SettingsData(set);
			SettingsForm settingsForm = new SettingsForm(data);
			return settingsForm.ShowDialog() == DialogResult.OK ? data : null;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			repositoryActions = new RepositoryActions(toolStripStatusLabel);
			taskDispatcher = new TaskDispatcher();

			SettingsData settings = new SettingsData(Settings.Default);
			
			if(!LoadVarsFromSettings(settings)) {
				settings = OpenSettings(settings);
				if(settings == null) {
					Close();
					return;
				}
			}

			LoadChangedSettings(settings, true);

			LoadGUIFromSettings(Settings.Default);
         OnSelectedProjectChanged(projectComboBox.SelectedIndex);
      }
		
		private void SaveLast(Settings settings) {
			settings.LastRevision = Revision;
			settings.LastUser = User;
			// Keep old selected project if the user was unable to select a new one
			settings.LastProject = projectComboBox.SelectedIndex == -1 ? lastSelectedProject : Project;
		}

      protected override void OnClosing(CancelEventArgs e) {
			base.OnClosing(e);

			Settings settings = Settings.Default;
	      SaveLast(settings);
         currentSettings?.Save(settings);
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

		private void OnSelectedProjectChanged(int index) {
			bool value = index != -1;
			ordnerToolStripMenuItem2.Enabled = value;
			updateToolStripMenuItem.Enabled = value;
			projektordnerToolStripMenuItem.Enabled = value;
			updateProjektordnerToolStripMenuItem.Enabled = value;
		}

		public Data MakeSnapshot() {
			return new Data(User, UserName, Project, Revision);
		}

		private string MakeOutputPath() {
			return Path.Combine(OutputFolder, Project, User);
		}
		
		#region UI Events

		private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e) {
			SettingsData settings = OpenSettings(currentSettings);

			if (settings != null)
				LoadChangedSettings(settings, false);
		}

		private void ordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!HasUser) return;
			string path = pathBuilder.GetUserProjects(User);
			if(Directory.Exists(path))
				Explorer.Open(path);
			else
				ShowError("Ordner von \"" + User + "\" konnte nicht gefunden werden. Wurde er schon geladen?");
		}

		private void projektordnerToolStripMenuItem_Click(object sender, EventArgs e) {
			if(!HasUser || !HasProject) return;
			string path = pathBuilder.GetUserProject(User, Project);
			if(Directory.Exists(path))
				Explorer.Open(path);
			else
				ShowError("Projektordner des Projekts \"" + Project + "\" von \"" + User +
				                "\" konnte nicht gefunden werden.");
		}

		private void ordnerToolStripMenuItem2_Click(object sender, EventArgs e) {
			if(HasProject) {
				string path = pathBuilder.GetProject(Project);
				if(Directory.Exists(path))
					Explorer.Open(path);
				else
					ShowError("Projektordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.");
			}
		}

		private void updateFolder(string path, string revision) {
			StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
			task.DoWork += (o, ev) => {
				task.Status = "Aktualisiere Ordner \"" + path + "\"";
				SubversionHelper.UpdateDir(repositoryActions.Client, path, SvnDepth.Infinity, revision);
			};
			task.RunWorkerCompleted += (sender, args) => {
				if(args.Error != null) HandleBackgroundException(args.Error);
			};
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
				ShowError("Ordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.");
		}

		private void userTextBox_TextChanged(object sender, EventArgs e) {
			UpdateUserName();
			OnUserChanged();
      }

		private void OnUserChanged() {
			bool value = !string.IsNullOrWhiteSpace(User);
			ordnerToolStripMenuItem.Enabled = value;
			projektordnerToolStripMenuItem.Enabled = value;
			updateProjektordnerToolStripMenuItem.Enabled = value;
      }

		private void nameTextBox_TextChanged(object sender, EventArgs e) {
			UpdateUser();
			OnUserChanged();
		}

		private ProjectForm MakeProjectForm(string destination, Data data, string updatedRevision) {
			return new ProjectForm(data, destination, intelliJIDEA, updatedRevision);
		}

		private void HandleExecutionFinished(string destination, Data data, RunWorkerCompletedEventArgs args) {
			if(args.Error != null) {
				HandleBackgroundException(args.Error);
			} else if(!args.Cancelled)
				MakeProjectForm(destination, data, args.Result as string).Show();
		}

		private void codeTestsToolStripMenuItem_Click(object sender, EventArgs e) {
			if(taskDispatcher.IsTaskRunning || !HasProject || !HasUser) return;
			var path = MakeOutputPath();
			var data = MakeSnapshot();
			var task = repositoryActions.CreateCopyAllTask(data, path, onlySrcFolderFromProject);
			task.RunWorkerCompleted += (s, ev) => { HandleExecutionFinished(path, data, ev); };
			taskDispatcher.Run(task);
		}

		private void codeToolStripMenuItem_Click(object sender, EventArgs e) {
			if (taskDispatcher.IsTaskRunning || !HasProject || !HasUser) return;
         var path = MakeOutputPath();
			var data = MakeSnapshot();
			var task = repositoryActions.CreateCopyProjectTask(data, path, onlySrcFolderFromProject);
			task.RunWorkerCompleted += (s, ev) => { HandleExecutionFinished(path, data, ev); };
			taskDispatcher.Run(task);
		}

      #endregion

      private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
	      OnSelectedProjectChanged(projectComboBox.SelectedIndex);
      }
   }
}
