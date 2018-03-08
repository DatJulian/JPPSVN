using SharpSvn;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    class CopyProjectTask : StatusBackgroundWorker {
        public string ProjectPath { get; set; }
        public string Destination { get; set; }
        public string Revision { get; set; }

        public CopyProjectTask(ToolStripStatusLabel label, string projectPath, string destination, string revision) : base(label) {
            ProjectPath = projectPath;
            Destination = destination;
            Revision = revision;
        }

        protected void CopyProject() {
            if(Directory.Exists(Destination)) {
                ReportStatus("Lösche alten Ordner");
                Directory.Delete(Destination, true);
            }

            ReportStatus("Erstelle Ordner");
            Directory.CreateDirectory(Destination);

            ReportStatus("Aktualisiere Projekt");
            using(SvnClient client = new SvnClient()) {
                client.Update(ProjectPath, new SvnUpdateArgs {
                    Revision = SubversionHelper.MakeRevision(Revision),
                    IgnoreExternals = true
                });
            }

            ReportStatus("Kopiere Projekt");
            DirectoryCopy.CopyIgnoreNotExists(
                Path.Combine(ProjectPath, "src"),
                Path.Combine(Destination, "src", "main", "java"),
                true);
        }
        
        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyProject();
        }
    }
}
