using System.Windows.Forms;

namespace JPPSVN.jpp {
    class RepositoryActions {
        private PathBuilder PathBuilder { get; set; }

        public ToolStripStatusLabel Label { get; set; }

        public RepositoryActions(ToolStripStatusLabel label, string repositoryFolder) {
            Label = label;
            PathBuilder = new PathBuilder(repositoryFolder);
        }
        
        public static bool IsValidUser(string user) {
            return user != null && user.Length == 7;
        }

        public CopyProjectAndTestsTask CopyAllTask(Data data, string destination) {
            return new CopyProjectAndTestsTask(
                Label,
                PathBuilder.GetUserProject(data.User, data.Project),
                destination,
                data.Revision,
                PathBuilder.GetProjectTests(data.Project)
            );
        }

        public CopyProjectTask CopyProjectTask(Data data, string destination) {
            return new CopyProjectTask(
                Label,
                PathBuilder.GetUserProject(data.User, data.Project),
                destination,
                data.Revision
            );
        }
    }
}
