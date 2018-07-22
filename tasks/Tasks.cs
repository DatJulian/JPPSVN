using System.ComponentModel;
using SharpSvn;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace JPPSVN.tasks {
	internal class Tasks {
		public const string EVIL_STRING = "pabs";

		public static void RewriteGradleFile(string path) {
			string temp = path + ".tmp";
			File.WriteAllLines(temp, File.ReadLines(path).Where(line => !line.Contains(EVIL_STRING)));
			File.Delete(path);
			File.Move(temp, path);
		}

		public static string[] GetSubDirectories(string path) {
			DirectoryInfo dir = new DirectoryInfo(path);
			if (!dir.Exists) return new string[0];
			DirectoryInfo[] dirs = dir.GetDirectories();
			string[] res = new string[dirs.Length];
			for (int i = 0; i < dirs.Length; i++) {
				res[i] = dirs[i].Name;
			}

			return res;
		}
		
      public class StartupUpdateTask : StatusBackgroundWorker {
			public SvnClient Client { get; }
			public string RepositoryUrl { get; }
			public PathBuilder PathBuilder { get; }
			public ClearnameResolver ClearnameResolver { get; set; }
			public string[] Projects { get; set; }

			public StartupUpdateTask(SvnClient client, ToolStripStatusLabel label, string repositoryURL, PathBuilder pathBuilder) : base(label) {
            Client = client;
            RepositoryUrl = repositoryURL;
	         PathBuilder = pathBuilder;
         }

			public void Execute() {
				if (string.IsNullOrEmpty(PathBuilder.BasePath))
					return;

				if (!SubversionHelper.IsSVNFolder(PathBuilder.BasePath))
					Client.CheckOut(new SvnUriTarget(RepositoryUrl), PathBuilder.BasePath, new SvnCheckOutArgs { Depth = SvnDepth.Children });
				
				Status = "Update clearnames";
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ViewsPath);
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ClearnamePath);
				
				Client.GetProperty(new SvnPathTarget(PathBuilder.ClearnamePath), "svn:externals", out string property);
				ClearnameResolver = ClearnameResolver.FromExternals(property);

				Status = "Update Projekte";
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ProjectsPath);

				Projects = GetSubDirectories(PathBuilder.ProjectsPath);
			}
      }

		public static void CopyTests(SvnClient client, StatusBackgroundWorker worker, string testSource, string destination) {
			worker.Status = "Update Tests";
			SubversionHelper.UpdateDir(client, testSource);

			worker.Status = "Kopiere Tests";
         DirectoryUtil.Copy(testSource, destination, true);

			worker.Status = "Schreibe build.gradle";
			RewriteGradleFile(destination + "\\build.gradle");
		}
	}
}
