using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using SharpSvn;

namespace JPPSVN.tasks {
	internal class CopyProjectTask {
		internal class CopyProjectArgs {
			public string Destination { get; }
			public string Revision { get; }
			public string ProjectsPath { get; }
			public string ProjectPath { get; }
			public bool OnlySrcFolderFromProject { get; }

         public CopyProjectArgs(string destination, string revision, string projectsPath, string project, bool onlySrcFolderFromProject) {
				Destination = destination;
				Revision = revision;
				ProjectsPath = projectsPath;
				ProjectPath = PathBuilder.UserProjectFromProjects(projectsPath, project);
				OnlySrcFolderFromProject = onlySrcFolderFromProject;
         }
		}

		public StatusBackgroundWorker Worker { get; }
		public SvnClient Client { get; }
		public string Destination { get; }
		public string Revision { get; }
		public string ProjectsPath { get; }
		public string ProjectPath { get; }
		public bool OnlySrcFolderFromProject { get; }
      public string UpdatedToRevision { get; private set; }
		

      protected string Status { set => Worker.Status = value; }

		public CopyProjectTask(StatusBackgroundWorker worker, SvnClient client, CopyProjectArgs args) {
			Worker = worker;
			Client = client;
			Destination = args.Destination;
			Revision = args.Revision;
			ProjectsPath = args.ProjectsPath;
			ProjectPath = args.ProjectPath;
			OnlySrcFolderFromProject = args.OnlySrcFolderFromProject;
		}

		public void DoWork(object sender, DoWorkEventArgs e) {
			CopyProject();
			e.Result = UpdatedToRevision;
		}

      public void CopyProject() {
			if (Directory.Exists(Destination)) {
				Status = "Lösche alten Ordner";
				DirectoryUtil.DeleteDirectory(Destination);
			}

			Status = "Aktualisiere Projekt";
			SubversionHelper.UpdateDir(Client, ProjectsPath, SvnDepth.Children, Revision); // Get all project folders

			if(!Directory.Exists(ProjectPath))
				return;

         SvnUpdateResult result;
         if (OnlySrcFolderFromProject) {
            SubversionHelper.UpdateDir(Client, Path.Combine(ProjectPath, "src"), SvnDepth.Infinity, out result, Revision);
         } else {
	         SubversionHelper.UpdateDir(Client, ProjectPath, SvnDepth.Infinity, out result, Revision);
         }
	      
			if(result.HasRevision)
				UpdatedToRevision = result.Revision.ToString();
			
         Status = "Kopiere Projekt";
			string srcPath = Path.Combine(ProjectPath, "src");
			string outDir = MavenStructure.IsDirectoryStructure(srcPath)
				? Path.Combine(Destination, "src")
				: Path.Combine(Destination, "src", "main", "java");
			DirectoryUtil.CopyIgnoreNotExists(srcPath, outDir, true);

			DirectoryUtil.CopyIgnoreNotExists(ProjectPath, Destination, true, s => "src" != s && ".idea" != s);
      }
	}
}