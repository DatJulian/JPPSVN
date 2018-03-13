using JPPSVN.jpp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace JPPSVN {
    public partial class MainForm : Form {
        private PathBuilder jppExtractor;
        private IntelliJIDEA intelliJIDEA;
        private TaskDispatcher<StatusBackgroundWorker> taskDispatcher;
        private RepositoryActions repositoryActions;

        #region Properties
        
        public string Revision {
            get => revisionTextBox.Text;
            set => revisionTextBox.Text = value;
        }

        public string User {
            get => userTextBox.Text;
            set => userTextBox.Text = value;
        }

        public string Project {
            get => projectTextBox.Text;
            set => projectTextBox.Text = value;
        }

        public string RepositoryFolder {
            get; set;
        }

        public string OutputFolder {
            get; set;
        }

        public string IDEAPath {
            get; set;
        }

        public string UserName {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        } 
        
        private bool HasUser => !string.IsNullOrEmpty(User) && User.Length == 7;

        private bool HasProject => !string.IsNullOrWhiteSpace(Project);

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

            if(!Validation.Main.IsValidRepositoryFolder(RepositoryFolder))
                return false;

            OutputFolder = settings.OutputFolder;

            if(!Validation.Main.IsValidOutputFolder(OutputFolder))
                return false;

            IDEAPath = IntelliJIDEA.FindExe(settings.AutoFindIDEA, settings.IDEAPath);

            if(!Validation.Main.IsValidIDEA(IDEAPath))
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
            if(!LoadVarsFromSettings(settings) && (new Settings().ShowDialog() != DialogResult.OK || !LoadVarsFromSettings(Properties.Settings.Default)))
                Close();
            
            jppExtractor = new PathBuilder(RepositoryFolder);

            LoadGUIFromSettings(settings);

            repositoryActions = new RepositoryActions(
                new PropertyReference<string>(() => revisionTextBox.Text),
                new PropertyReference<string>(() => userTextBox.Text),
                new PropertyReference<string>(() => projectTextBox.Text),
                RepositoryFolder,
                OutputFolder);

            taskDispatcher = new TaskDispatcher<StatusBackgroundWorker>();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            Properties.Settings settings = Properties.Settings.Default;
            SaveToSettings(settings);
            settings.Save();
        }

        static StatusBackgroundWorker OpenExplorerAfter(CopyProjectTask task) {
            task.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
                Explorer.Open(task.Destination);
            };

            return task;
        }

        StatusBackgroundWorker OpenIntelliJAfter(CopyProjectTask task) {
            task.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
                intelliJIDEA.Open(task.Destination);
            };

            return task;
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
                    MessageBox.Show("Projektordner des Projekts \"" + Project + "\" von \"" + User + "\" konnte nicht gefunden werden.");
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

        private string MakeOutputPath() {
            return Path.Combine(OutputFolder, Project, User);
        }

        private void erstellteOrdnerLöschenToolStripMenuItem_Click(object sender, EventArgs e) {
            if(!taskDispatcher.IsTaskRunning && HasProject && HasUser) {
                string path = MakeOutputPath();
                StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
                task.DoWork += (object o, DoWorkEventArgs ev) => {
                    task.ReportStatus("Lösche Ordner \"" + path + "\"");
                    if(Directory.Exists(path)) Directory.Delete(path, true);
                };
                taskDispatcher.Run(task);
            }
        }

        private void updateFolder(string path, string revision) {
            StatusBackgroundWorker task = new StatusBackgroundWorker(toolStripStatusLabel);
            task.DoWork += (object o, DoWorkEventArgs ev) => {
                task.ReportStatus("Aktualisiere Ordner \"" + path + "\"");
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
                    MessageBox.Show(this, "Projektordner des Projekts \"" + Project + "\" konnte nicht gefunden werden.", "Fehler");
            }
        }

        private void userTextBox_TextChanged(object sender, EventArgs e) {
            UserName = jppExtractor.ResolveUsername(userTextBox.Text);
        }

        private ProjectForm MakeProjectForm(string destination) {
            return new ProjectForm(new ProjectForm.ProjectFormArgs() {
                Folder = destination,
                User = User,
                Project = Project,
                Revision = Revision,
                IntelliJ = intelliJIDEA
            });
        }

        private void HandleExecutionFinished(CopyProjectTask task, RunWorkerCompletedEventArgs args) {
            if(args.Error != null) {
                MessageBox.Show(this, args.Error.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(!args.Cancelled)
                MakeProjectForm(task.Destination).Show();
        }

        private void codeTestsToolStripMenuItem_Click(object sender, EventArgs e) {
            if(taskDispatcher.IsTaskRunning) return;
            var task = repositoryActions.CopyAllTask(toolStripStatusLabel, MakeOutputPath());
            task.RunWorkerCompleted += (object s, RunWorkerCompletedEventArgs ev) => {
                HandleExecutionFinished(task, ev);
            };
            taskDispatcher.Run(task);
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e) {
            if(taskDispatcher.IsTaskRunning) return;
            var task = repositoryActions.CopyProjectTask(toolStripStatusLabel, MakeOutputPath());
            task.RunWorkerCompleted += (object s, RunWorkerCompletedEventArgs ev) => {
                HandleExecutionFinished(task, ev);
            };
            taskDispatcher.Run(task);
        }

        #endregion
    }
}
