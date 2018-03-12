using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    public partial class ProjectForm : Form {
        internal class ProjectFormArgs {
            internal string Folder { get; set; }
            internal string User { get; set; }
            internal string Project { get; set; }
            internal string Revision { get; set; }
            internal IntelliJIDEA IntelliJ { get; set; }
        }

        private TaskDispatcher<BackgroundWorker> taskDispatcher;

        internal ProjectFormArgs Args {
            get; private set;
        }
        
        internal ProjectForm(ProjectFormArgs args) {
            Args = args;
            InitializeComponent();
        }
        
        private void openIntelliJButton_Click(object sender, EventArgs e) {
            Args.IntelliJ.Open(Args.Folder);
        }

        private void openExplorerButton_Click(object sender, EventArgs e) {
            Explorer.Open(Args.Folder);
        }

        private void cleanupButton_Click(object sender, EventArgs e) {
            if(taskDispatcher.IsTaskRunning) return;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += (object o, DoWorkEventArgs ev) => {
                if(Directory.Exists(Args.Folder)) Directory.Delete(Args.Folder, true);
            };
            task.RunWorkerCompleted += (object snder, RunWorkerCompletedEventArgs es) => {
                Close();
            };
            taskDispatcher.Run(task);
        }

        private void ProjectForm_Load(object sender, EventArgs e) {
            taskDispatcher = new TaskDispatcher<BackgroundWorker>();
            string res = Args.User + " (" + Args.Project;
            if(!string.IsNullOrEmpty(Args.Revision))
                res += " Revision " + Args.Revision;
            res += ")";
            Text = res;
        }
    }
}
