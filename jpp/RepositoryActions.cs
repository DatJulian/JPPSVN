using System;
using JPPSVN.tasks;
using System.Windows.Forms;
using SharpSvn;

namespace JPPSVN.jpp {
	internal class RepositoryActions : IDisposable {
		private PathBuilder PathBuilder { get; }

		public ToolStripStatusLabel Label { get; }

		public SvnClient Client { get; }

		public RepositoryActions(ToolStripStatusLabel label, string repositoryFolder) {
			Client = new SvnClient();
			Label = label;
			PathBuilder = new PathBuilder(repositoryFolder);
		}

		public StatusBackgroundWorker StartupUpdate(string RepositoryURL) {
			var worker = new StatusBackgroundWorker(Label);
			var task = new Tasks.StartupUpdateTask(Client, worker, RepositoryURL, PathBuilder);
         worker.DoWork += (sender, e) => {
	         task.Execute();
	         e.Result = task;
         };
			return worker;
		}

		public CopyProjectAndTestsTask CopyAllTask(Data data, string destination) {
			return new CopyProjectAndTestsTask(
				Client,
				Label,
				PathBuilder.GetUserProjects(data.User),
				data.Project,
            destination,
				data.Revision,
				PathBuilder.GetProjectTests(data.Project)
			);
		}

		public CopyProjectTask CopyProjectTask(Data data, string destination) {
			return new CopyProjectTask(
				Client,
				Label,
				PathBuilder.GetUserProjects(data.User),
				data.Project,
				destination,
				data.Revision
			);
		}

		public void Dispose() {
			Client.Dispose();
		}
	}
}
