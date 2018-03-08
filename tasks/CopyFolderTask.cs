using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    class DeleteFolderTask : StatusBackgroundWorker {
        public DeleteFolderTask(ToolStripStatusLabel label, string path) : base(label) {
            Path = path;
        }

        public string Path { get; set; }

        private void CopyFolder() {
            ReportStatus("Delete folder \"" + Path + "\"");
            if(Directory.Exists(Path)) Directory.Delete(Path, true);
        }

        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyFolder();
        }
    }
}
