using JPPSVN.tasks;
using System.ComponentModel;
using System.Windows.Forms;
using SharpSvn;

namespace JPPSVN {
	internal class CopyProjectAndTestsTask : CopyProjectTask {

        public CopyProjectAndTestsTask(
	        SvnClient client, 
	        ToolStripStatusLabel label,
	        string projectsPath,
	        string project,
	        string destination,
	        string revision,
	        string testSource) : base(client, label, projectsPath, project, destination, revision) {
            TestSource = testSource;
        }

        public string TestSource { get; set; }

        protected void CopyTests() {
            Tasks.CopyTests(Client, this, TestSource, Destination);
        }

        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyTests();
        }
    }
}
