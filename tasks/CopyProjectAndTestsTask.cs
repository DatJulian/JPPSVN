using System.ComponentModel;
using SharpSvn;

namespace JPPSVN.tasks {
	internal class CopyProjectAndTestsTask : CopyProjectTask {
		public string TestSource { get; }

		public CopyProjectAndTestsTask(StatusBackgroundWorker worker, SvnClient client, CopyProjectArgs args, string testSource) : base(worker, client, args) {
			TestSource = testSource;
		}

		public void CopyProjectAndTests() {
			CopyProject();
			CopyTests();
		}

		public new void DoWork(object sender, DoWorkEventArgs e) {
			base.DoWork(sender, e);
			CopyProjectAndTests();
		}

      protected void CopyTests() {
			Status = "Update Tests";
			SubversionHelper.UpdateDir(Client, TestSource, out _);

			Status = "Kopiere Tests";
			DirectoryUtil.CopyIgnoreNotExists(TestSource, Destination, true);
			
	      Status = "Schreibe build.gradle";
	      Tasks.RewriteGradleFile(Destination + "\\build.gradle");
      }
	}
}
