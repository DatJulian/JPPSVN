using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace JPPSVN {
    class PathBuilder {
        private const string CLEARNAME_PATH_1 = "views",
            CLEARNAME_PATH_2 = "clearname",
            UNKNOWN_STUDENT_NAME = "unbekannt",
            USERPROJECTS_PATH = "users",
            PROJECTS_PATH = "assignments",
            EVIL_STRING = "pabs";
        private static readonly Regex NAME_REGEX = new Regex("^(.*) - [a-z0-9]+$");
        
        private string basePath, clearnamePath, projectsPath, userProjectsPath;

        public string BasePath => basePath;

        public PathBuilder(string path) {
            basePath = path;
            clearnamePath = Path.Combine(path, CLEARNAME_PATH_1, CLEARNAME_PATH_2);
            projectsPath = Path.Combine(path, PROJECTS_PATH);
            userProjectsPath = Path.Combine(path, USERPROJECTS_PATH);

            if(!Directory.Exists(basePath)) throw new DirectoryNotFoundException("Base directory \"" + basePath +  "\" not found!");
            if(!Directory.Exists(clearnamePath)) throw new DirectoryNotFoundException("Clear name directory \"" + clearnamePath +  "\" not found!");
            if(!Directory.Exists(projectsPath)) throw new DirectoryNotFoundException("Projects directory \"" + projectsPath +  "\" not found!");
            if(!Directory.Exists(userProjectsPath)) throw new DirectoryNotFoundException("Userprojects directory \"" + userProjectsPath +  "\" not found!");
        }

        public string ResolveUsername(string user) {
            if(user == null || user.Length != 7) return UNKNOWN_STUDENT_NAME;
            string[] arr = Directory.GetDirectories(clearnamePath, "*" + user, SearchOption.TopDirectoryOnly);
            if(arr.Length == 0) return UNKNOWN_STUDENT_NAME;
            if(arr.Length > 1) return "Nicht eindeutig";
            string text = arr[0];
            int lastPath = text.LastIndexOf('\\') + 1;
            text = text.Substring(lastPath, text.Length - lastPath);
            Match m = NAME_REGEX.Match(text);
            return m.Success ? m.Groups[1].Value : UNKNOWN_STUDENT_NAME;
        }

        public string GetProject(string project) {
            return Path.Combine(projectsPath, project);
        }

        public string GetProjectTests(string project) {
            return Path.Combine(GetProject(project), "project");
        }

        public string GetUserProjects(string user) {
            return Path.Combine(userProjectsPath, user);
        }

        public string GetUserProject(string user, string project) {
            return Path.Combine(GetUserProjects(user), project);
        }

        public static void RewriteFile(string path) {
            File.WriteAllLines(path + ".tmp", File.ReadLines(path).Where(lineInt => !lineInt.Contains(EVIL_STRING)));
            File.Delete(path);
            File.Move(path + ".tmp", path);
        }

        public void CopyProject(string snummer, string project, string target) {
            string path = GetUserProject(snummer, project);
            DirectoryCopy.Copy(path, target, true);
        }
    }
}
