using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JPPSVN {
    class PathBuilder {
        private const string CLEARNAME_PATH_1 = "views",
            CLEARNAME_PATH_2 = "clearname",
            UNKNOWN_STUDENT_NAME = "unbekannt",
            USERPROJECTS_PATH = "users",
            PROJECTS_PATH = "assignments";

        private static readonly Regex NAME_REGEX = new Regex("^(.*) - [a-z0-9]+$");
        
        public string BasePath { get; private set; }
        public string ClearnamePath { get; private set; }
        public string ProjectsPath { get; private set; }
        public string UserProjectsPath { get; private set; }

        public PathBuilder(string path) {
            BasePath = path;
            ClearnamePath = Path.Combine(path, CLEARNAME_PATH_1, CLEARNAME_PATH_2);
            ProjectsPath = Path.Combine(path, PROJECTS_PATH);
            UserProjectsPath = Path.Combine(path, USERPROJECTS_PATH);

            if(!Directory.Exists(BasePath)) throw new DirectoryNotFoundException("Base directory \"" + BasePath +  "\" not found!");
            if(!Directory.Exists(ClearnamePath)) throw new DirectoryNotFoundException("Clear name directory \"" + ClearnamePath +  "\" not found!");
            if(!Directory.Exists(ProjectsPath)) throw new DirectoryNotFoundException("Projects directory \"" + ProjectsPath +  "\" not found!");
            if(!Directory.Exists(UserProjectsPath)) throw new DirectoryNotFoundException("Userprojects directory \"" + UserProjectsPath +  "\" not found!");
        }

        public string ResolveUsername(string user) {
            if(user == null || user.Length != 7) return UNKNOWN_STUDENT_NAME;
            string[] arr = Directory.GetDirectories(ClearnamePath, "*" + user, SearchOption.TopDirectoryOnly);
            if(arr.Length == 0) return UNKNOWN_STUDENT_NAME;
            if(arr.Length > 1) return "Nicht eindeutig";
            string text = arr[0];
            int lastPath = text.LastIndexOf('\\') + 1;
            text = text.Substring(lastPath, text.Length - lastPath);
            Match m = NAME_REGEX.Match(text);
            return m.Success ? m.Groups[1].Value : UNKNOWN_STUDENT_NAME;
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

        public string GetUserProject(string user, string project) {
            return Path.Combine(GetUserProjects(user), project);
        }

        public void CopyProject(string snummer, string project, string target) {
            string path = GetUserProject(snummer, project);
            DirectoryCopy.Copy(path, target, true);
        }

        public string[] GetProjects() {
            DirectoryInfo path = new DirectoryInfo(ProjectsPath);
            if(!path.Exists) return new string[0];
            DirectoryInfo[] dirs = path.GetDirectories();
            string[] res = new string[dirs.Length];
            for(int i = 0; i < dirs.Length; i++) {
                res[i] = dirs[i].Name;
            }
            return res;
        }
    }
}
