using SharpSvn;
using System.IO;
using System.Linq;
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
	      protected SvnClient Client { get; }
	      protected string RepositoryUrl { get; }
	      protected PathBuilder PathBuilder { get; }
	      protected bool UrlChanged { get; }
         public ClearnameResolver ClearnameResolver { get; set; }
			public string[] Projects { get; set; }
			

			public StartupUpdateTask(SvnClient client, ToolStripStatusLabel label, string repositoryURL, PathBuilder pathBuilder, bool urlChanged) : base(label) {
            Client = client;
            RepositoryUrl = repositoryURL;
	         PathBuilder = pathBuilder;
				UrlChanged = urlChanged;
			}

	      private void CheckoutRepo() {
		      Status = "Checking out repository";
            Client.CheckOut(new SvnUriTarget(RepositoryUrl), PathBuilder.BasePath, new SvnCheckOutArgs { Depth = SvnDepth.Children });
         }

			public void Execute() {
				if (string.IsNullOrEmpty(PathBuilder.BasePath))
					return;

				if(Directory.Exists(PathBuilder.BasePath)) {
					if(SubversionHelper.IsSVNFolder(Client, PathBuilder.BasePath)) {
						Status = "Cleaning up repository";
                  Client.CleanUp(PathBuilder.BasePath);
					}

					if(UrlChanged)
						CheckoutRepo();
            } else {
					CheckoutRepo();
				}

				Status = "Updating clearnames";
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ViewsPath);
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ClearnamePath);
				
				Client.GetProperty(new SvnPathTarget(PathBuilder.ClearnamePath), "svn:externals", out string property);
				ClearnameResolver = ClearnameResolver.FromExternals(property);

				Status = "Updating projects";
				SubversionHelper.UpdateDirNonRecursive(Client, PathBuilder.ProjectsPath);

				Projects = GetSubDirectories(PathBuilder.ProjectsPath);
			}
      }
	}
}
