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

		protected void CopyTests() {
			Status = "Update Tests";
			SubversionHelper.UpdateDir(Client, TestSource);

			Status = "Kopiere Tests";
			DirectoryUtil.Copy(TestSource, Destination, true);

			Status = "Schreibe build.gradle";
			Tasks.RewriteGradleFile(Destination + "\\build.gradle");
      }
	}
}
