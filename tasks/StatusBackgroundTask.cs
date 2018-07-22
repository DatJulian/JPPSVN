using System.ComponentModel;
using System.Windows.Forms;

namespace JPPSVN.tasks {
	internal class StatusBackgroundWorker : BackgroundWorker {
        public ToolStripStatusLabel Label { get; set; }

        public string Status {
            set => ReportProgress(0, new ProgressInformation(value));
        }
        
        public StatusBackgroundWorker(ToolStripStatusLabel label) {
            Label = label;
            WorkerReportsProgress = true;
            Label.Text = "";
            Label.Visible = true;
        }

        protected override void OnProgressChanged(ProgressChangedEventArgs e) {
            base.OnProgressChanged(e);

            ProgressInformation info = e.UserState as ProgressInformation;
            if(info?.StatusText != null)
                Label.Text = info.StatusText;
        }

        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e) {
            base.OnRunWorkerCompleted(e);
            Label.Visible = false;
        }
        
        public class ProgressInformation {
            public string StatusText { get; set; }
            
            public ProgressInformation(string text) {
                StatusText = text;
            }
        }
    }
}
