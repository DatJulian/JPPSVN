﻿using System.ComponentModel;
using System.IO;
using SharpSvn;

namespace JPPSVN.tasks {
	internal class CopyProjectTask {
		internal class CopyProjectArgs {
			public string Destination { get; }
			public string Revision { get; }
			public string ProjectsPath { get; }
			public string ProjectPath { get; }

			public CopyProjectArgs(string destination, string revision, string projectsPath, string project) {
				Destination = destination;
				Revision = revision;
				ProjectsPath = projectsPath;
				ProjectPath = PathBuilder.UserProjectFromProjects(projectsPath, project);
			}
		}

		public StatusBackgroundWorker Worker { get; }
		public SvnClient Client { get; }
		public string Destination { get; }
		public string Revision { get; }
		public string ProjectsPath { get; }
		public string ProjectPath { get; }
		public string UpdatedToRevision { get; private set; }

      protected string Status { set => Worker.Status = value; }

		public CopyProjectTask(StatusBackgroundWorker worker, SvnClient client, CopyProjectArgs args) {
			Worker = worker;
			Client = client;
			Destination = args.Destination;
			Revision = args.Revision;
			ProjectsPath = args.ProjectsPath;
			ProjectPath = args.ProjectPath;
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
         SubversionHelper.UpdateDirNonRecursive(Client, ProjectsPath, Revision);
	      SubversionHelper.UpdateDir(Client, ProjectPath, out var result, Revision);

			if(result.HasRevision)
				UpdatedToRevision = result.Revision.ToString();

			// TODO copy other files outside of src/ too
         Status = "Kopiere Projekt";
			string srcPath = Path.Combine(ProjectPath, "src");
			string outDir = MavenStructure.IsDirectoryStructure(srcPath)
				? Path.Combine(Destination, "src")
				: Path.Combine(Destination, "src", "main", "java");
			DirectoryUtil.CopyIgnoreNotExists(srcPath, outDir, true);
			DirectoryUtil.CopyIgnoreNotExists(ProjectPath, Destination, true, s => "src" != s);
      }
	}
}
