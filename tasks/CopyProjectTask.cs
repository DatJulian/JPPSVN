using SharpSvn;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
	internal class CopyProjectTask : StatusBackgroundWorker {
		public string Destination { get; }
		public string Revision { get; }
		public SvnClient Client { get; }
		public string ProjectsPath { get; }
		public string ProjectPath { get; }
		public string Project { get; }
		
      public CopyProjectTask(
	      SvnClient client,
	      ToolStripStatusLabel label, 
	      string projectsPath, 
	      string project, 
	      string destination, 
	      string revision) : base(label) {
			Client = client;
	      ProjectsPath = projectsPath;
			Destination = destination;
			Revision = revision;
	      Project = project;
	      ProjectPath = PathBuilder.UserProjectFromProjects(ProjectsPath, Project);
      }

		protected void CopyProject() {
			if (Directory.Exists(Destination)) {
				Status = "Lösche alten Ordner";
				DirectoryUtil.DeleteDirectory(Destination);
			}

			Status = "Aktualisiere Projekt";
         SubversionHelper.UpdateDirNonRecursive(Client, ProjectsPath, Revision);
			SubversionHelper.UpdateDir(Client, ProjectPath, Revision);

         Status = "Kopiere Projekt";
			string srcPath = Path.Combine(ProjectPath, "src");
			string outDir = MavenStructure.IsDirectoryStructure(srcPath)
				? Path.Combine(Destination, "src")
				: Path.Combine(Destination, "src", "main", "java");
			DirectoryUtil.CopyIgnoreNotExists(srcPath, outDir, true);
      }

		protected override void OnDoWork(DoWorkEventArgs e) {
			base.OnDoWork(e);
			CopyProject();
		}
	}
}
