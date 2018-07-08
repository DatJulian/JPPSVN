using System.IO;

namespace JPPSVN {
	internal class PathBuilder {
		private const string VIEWS_PATH = "views",
			CLEARNAME_SUBPATH = "clearname",
			USERPROJECTS_PATH = "users",
			PROJECTS_PATH = "assignments";

		public string BasePath { get; }
		public string ViewsPath { get; }
		public string ClearnamePath { get; }
		public string ProjectsPath { get; }
		public string UserProjectsPath { get; }
		

      public PathBuilder(string path) {
			BasePath = path;
			ViewsPath = Path.Combine(path, VIEWS_PATH);
         ClearnamePath = Path.Combine(ViewsPath, CLEARNAME_SUBPATH);
			ProjectsPath = Path.Combine(path, PROJECTS_PATH);
			UserProjectsPath = Path.Combine(path, USERPROJECTS_PATH);
		}
		
		public string GetProject(string project) {
			return Path.Combine(ProjectsPath, project);
		}

		public string GetProjectTests(string project) {
			return Path.Combine(GetProject(project), "project");
		}

		public string GetUserProjects(string user) {
			return Path.Combine(UserProjectsPath, user);
		}

		public static string UserProjectFromProjects(string projects, string project) {
			return Path.Combine(projects, project);
		}

      public string GetUserProject(string user, string project) {
			return UserProjectFromProjects(GetUserProjects(user), project);
		}
	}
}
