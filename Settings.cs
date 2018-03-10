using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPPSVN {
    public partial class Settings : Form {

        public string RepositoryFolder {
            get => repositoryFolderSelectionComponent.Path;
            set => repositoryFolderSelectionComponent.Path = value;
        }

        public string OutputFolder {
            get => outputFolderSelectionComponent.Path;
            set => outputFolderSelectionComponent.Path = value;
        }
        
        public string IdeaFolder {
            get => ideaFolderSelectionComponent.Path;
            set => ideaFolderSelectionComponent.Path = value;
        }

        public bool AutoFindIDEA {
            get => ideaFindAutomaticCheckBox.Checked;
            set => ideaFindAutomaticCheckBox.Checked = value;
        }

        public Settings() {
            InitializeComponent();
        }
        
        private void LoadFromSettings(Properties.Settings settings) {
            RepositoryFolder = settings.RepositoryFolder;
            OutputFolder = settings.OutputFolder;
            IdeaFolder = settings.IDEAPath;
            AutoFindIDEA = settings.AutoFindIDEA;
        }

        private void SaveToSettings(Properties.Settings settings) {
            settings.RepositoryFolder = RepositoryFolder;
            settings.OutputFolder = OutputFolder;
            settings.IDEAPath = IdeaFolder;
            settings.AutoFindIDEA = AutoFindIDEA;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Properties.Settings settings = Properties.Settings.Default;

            LoadFromSettings(settings);
            
            if(AutoFindIDEA)
                IdeaFolder = IntelliJIDEA.FindPath();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if(DialogResult == DialogResult.OK) {
                Properties.Settings settings = Properties.Settings.Default;

                SaveToSettings(settings);

                settings.Save();
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void ideaFindAutomaticCheckBox_CheckedChanged(object sender, EventArgs e) {
            ideaFolderSelectionComponent.Enabled = !ideaFindAutomaticCheckBox.Checked;
        }
    }
}
