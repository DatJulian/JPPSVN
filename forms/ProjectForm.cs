using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    public partial class ProjectForm : Form {
        internal class ProjectFormArgs {
            internal Data Data { get; set; }
            internal string Folder { get; set; }
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

        private void Cleanup() {
            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += (object o, DoWorkEventArgs ev) => {
                if(Directory.Exists(Args.Folder)) Directory.Delete(Args.Folder, true);
            };
            task.RunWorkerCompleted += (object snder, RunWorkerCompletedEventArgs es) => {
                Close();
            };
            taskDispatcher.Run(task);
        }

        private static string MakeTitle(Data data) {
            string res = data.UserName + " (" + data.Project;
            if(!string.IsNullOrEmpty(data.Revision))
                res += " Revision " + data.Revision;
            res += ")";
            return res;
        }

        private void cleanupButton_Click(object sender, EventArgs e) {
            Cleanup();
        }
        
        private void ProjectForm_Load(object sender, EventArgs e) {
            taskDispatcher = new TaskDispatcher<BackgroundWorker>();
            
            Text = MakeTitle(Args.Data);
        }

        private void ProjectForm_FormClosing(object sender, FormClosingEventArgs e) {
            Cleanup();
        }
    }
}
