using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPPSVN.jpp {
    class RepositoryActions {
        private PropertyReference<string> RevisionProperty, UserProperty, ProjectProperty;

        private PathBuilder pathBuilder;

        public string Revision => RevisionProperty.Value;

        public string User => UserProperty.Value;

        public string Project => ProjectProperty.Value;

        public bool HasUser => IsValidUser(User);

        public bool HasProject => !string.IsNullOrWhiteSpace(Project);

        public string RepositoryFolder {
            get; private set;
        }

        public RepositoryActions(
            PropertyReference<string> revisionProperty, 
            PropertyReference<string> userProperty, 
            PropertyReference<string> projectProperty,
            string repositoryFolder, 
            string outputFolder) {
            RevisionProperty = revisionProperty;
            UserProperty = userProperty;
            ProjectProperty = projectProperty;
            RepositoryFolder = repositoryFolder;
            pathBuilder = new PathBuilder(repositoryFolder);
        }
        
        public static bool IsValidUser(string user) {
            return user != null && user.Length == 7;
        }

        public CopyProjectTask CopyAllTask(ToolStripStatusLabel label, string destination) {
            return new CopyProjectAndTestsTask(
                label,
                pathBuilder.GetUserProject(User, Project),
                destination,
                Revision,
                pathBuilder.GetProjectTests(Project)
            );
        }

        public CopyProjectTask CopyProjectTask(ToolStripStatusLabel label, string destination) {
            return new CopyProjectTask(
                label,
                pathBuilder.GetUserProject(User, Project),
                destination,
                Revision
            );
        }
    }
}
