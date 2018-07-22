using System;
using JPPSVN.tasks;
using System.Windows.Forms;
using SharpSvn;

namespace JPPSVN.jpp {
	internal class RepositoryActions : IDisposable {
		public PathBuilder PathBuilder { get; set; }

		public ToolStripStatusLabel Label { get; }

		public SvnClient Client { get; }

		public RepositoryActions(ToolStripStatusLabel label) {
			Client = new SvnClient();
			Label = label;
		}

		public Tasks.StartupUpdateTask StartupUpdate(string RepositoryURL) {
			var task = new Tasks.StartupUpdateTask(Client, Label, RepositoryURL, PathBuilder);
			task.DoWork += (sender, e) => {
	         task.Execute();
	         e.Result = task;
         };
			return task;
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
