using SharpSvn;
using System.IO;
using System.Linq;

namespace JPPSVN.tasks {
    class Tasks {
        public const string EVIL_STRING = "pabs";

        public static void RewriteGradleFile(string path) {
            string temp = path + ".tmp";
            File.WriteAllLines(temp, File.ReadLines(path).Where(line => !line.Contains(EVIL_STRING)));
            File.Delete(path);
            File.Move(temp, path);
        }

        public static void CopyTests(StatusBackgroundWorker worker, string testSource, string destination) {
            worker.Status = "Kopiere Tests";
            DirectoryCopy.Copy(testSource, destination, true);

            worker.Status = "Schreibe build.gradle";
            RewriteGradleFile(destination + "\\build.gradle");
        }
        
        public static void CopyProject(StatusBackgroundWorker worker, string projectPath, string revision, string destination) {
            if(Directory.Exists(destination)) {
                worker.Status = "Lösche alten Ordner";
                Directory.Delete(destination, true);
            }

            worker.Status = "Erstelle Ordner";
            Directory.CreateDirectory(destination);

            worker.Status = "Aktualisiere Projekt";
            using(SvnClient client = new SvnClient()) {
                client.Update(projectPath, new SvnUpdateArgs {
                    Revision = SubversionHelper.MakeRevision(revision),
                    IgnoreExternals = true
                });
            }

            worker.Status = "Kopiere Projekt";
            string srcPath = Path.Combine(projectPath, "src");
            string outDir = MavenStructure.IsDirectoryStructure(srcPath) ? Path.Combine(destination, "src") : Path.Combine(destination, "src", "main", "java");
            DirectoryCopy.CopyIgnoreNotExists(srcPath, outDir, true);
        }
    }
}
