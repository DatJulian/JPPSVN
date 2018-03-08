using System.ComponentModel;
using System.Windows.Forms;

namespace JPPSVN {
    class CopyProjectAndTestsTask : CopyProjectTask {

        public CopyProjectAndTestsTask(ToolStripStatusLabel label, string projectPath, string destination, string revision, string testSource) : base(label, projectPath, destination, revision) {
            TestSource = testSource;
        }

        public string TestSource { get; set; }

        protected void CopyTests() {
            ReportStatus("Kopiere Tests");
            DirectoryCopy.Copy(TestSource, Destination, true);

            ReportStatus("Schreibe build.gradle");
            PathBuilder.RewriteFile(Destination + "\\build.gradle");
        }

        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyTests();
        }
    }
}
