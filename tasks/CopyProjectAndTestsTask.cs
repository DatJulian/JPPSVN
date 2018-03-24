using JPPSVN.tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace JPPSVN {
    class CopyProjectAndTestsTask : CopyProjectTask {

        public CopyProjectAndTestsTask(ToolStripStatusLabel label, string projectPath, string destination, string revision, string testSource) : base(label, projectPath, destination, revision) {
            TestSource = testSource;
        }

        public string TestSource { get; set; }

        protected void CopyTests() {
            Tasks.CopyTests(this, TestSource, Destination);
        }

        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyTests();
        }
    }
}
