using JPPSVN.tasks;
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
            Tasks.CopyProject(this, ProjectPath, Revision, Destination);
        }
        
        protected override void OnDoWork(DoWorkEventArgs e) {
            base.OnDoWork(e);
            CopyProject();
        }
    }
}
