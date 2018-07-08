using System.Collections.Generic;
using System.IO;

namespace JPPSVN {
    internal static class MavenStructure {
        private static readonly HashSet<string> MAIN_TEST_HS = new HashSet<string>(new [] { "main", "test" }),
            JAVA_RESOURCES_HS = new HashSet<string>(new[] { "java", "resources" });

        private static bool IsEmptyExceptDirs(string path, HashSet<string> dirsSet) {
            DirectoryInfo info = new DirectoryInfo(path);
            if(info.GetFiles().Length != 0) return false;

            foreach(DirectoryInfo subDir in info.EnumerateDirectories()) {
                if(!dirsSet.Contains(subDir.Name))
                    return false;
            }
            return true;
        }

        public static bool IsSubDirectory(string path) {
            return IsEmptyExceptDirs(path, JAVA_RESOURCES_HS);
        }

        public static bool IsDirectoryStructure(string path) {
            if(!(Directory.Exists(Path.Combine(path, "main", "java")) 
                && IsEmptyExceptDirs(path, MAIN_TEST_HS) 
                && IsSubDirectory(Path.Combine(path, "main"))))
                return false;
            string testPath = Path.Combine(path, "test");
            return !Directory.Exists(testPath) || IsSubDirectory(testPath);
        }
    }
}
