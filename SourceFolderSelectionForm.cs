using SharpSvn;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    public partial class SourceFolderSelectionForm : Form {
        BackgroundWorker worker;

        public SourceFolderSelectionForm() {
            InitializeComponent();
            useExistingRadioButton.Checked = true;
            targetFolderSelectionComponent.Path = @"E:\test_jpp";
            urlTextBox.Text = "https://pabs.uni-wuerzburg.de/repos/ws17_pp";
        }

        private void createNewRadioButton_CheckedChanged(object sender, EventArgs e) {
            if(createNewRadioButton.Checked) useExistingRadioButton.Checked = false;
            createNewTableLayoutPanel.Enabled = createNewRadioButton.Checked;
            useExistingTableLayoutPanel.Enabled = !createNewRadioButton.Checked;
        }

        private void useExistingRadioButton_CheckedChanged(object sender, EventArgs e) {
            if(useExistingRadioButton.Checked) createNewRadioButton.Checked = false;
            useExistingTableLayoutPanel.Enabled = useExistingRadioButton.Checked;
            createNewTableLayoutPanel.Enabled = !useExistingRadioButton.Checked;
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if(useExistingRadioButton.Checked) proceedUsingExisting();
            else proceedCreatingNew();
        }

        private bool checkRepoPath(string path) {
            if(!Directory.Exists(path)) {
                MessageBox.Show("Der ausgewählte Repository-Ordner existiert nicht.");
                return false;
            } else if(!SubversionHelper.IsSVNFolder(path)) {
                MessageBox.Show("Der ausgewählte Repository-Ordner ist keine SVN repository.");
                return false;
            }
            return true;
        }

        private void proceedUsingExisting() {
            string path = useExistingFolderSelectionComponent.Path;

            if(string.IsNullOrWhiteSpace(path)) {
                MessageBox.Show("Es muss ein Repository-Ordner ausgewählt sein.");
            } else if(checkRepoPath(path)) {
                Properties.Settings.Default.RepositoryFolder = path;
                Close();
            }
        }

        private bool checkIfFolderExistsAndDelete(string path) {
            if(Directory.Exists(path)) {
                DialogResult r = MessageBox.Show(this, "\"" + path + "\" already exists. Do you want to delete it?", "Folder already exists", MessageBoxButtons.OKCancel);
                switch(r) {
                    case DialogResult.OK:
                        Directory.Delete(path, true);
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        private void proceedCreatingNew() {
            string path = targetFolderSelectionComponent.Path, url = urlTextBox.Text;

            if(string.IsNullOrWhiteSpace(path)) {
                MessageBox.Show("Es muss ein Repository-Ordner ausgewählt sein.");
            } else {
                if(!checkIfFolderExistsAndDelete(path)) return;
                
                nextButton.Enabled = false;
                worker = new BackgroundWorker();

                worker.DoWork += (object s, DoWorkEventArgs args) => {
                    bool b;
                    using(SvnClient client = new SvnClient()) {

                        client.Progress += (object sender, SvnProgressEventArgs e) => {
                            worker.ReportProgress((int)e.Progress, e);
                        };

                        try {
                            b = client.CheckOut(SvnUriTarget.FromString(url), path, out SvnUpdateResult res);
                        } catch(SvnException e) {
                            MessageBox.Show("An SvnException has occured: " + e.Message);
                        } catch(Exception e) {
                            MessageBox.Show("An Exception has occured: " + e.ToString());
                        }
                    }
                };

                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
                    nextButton.Enabled = true;
                    Properties.Settings.Default.RepositoryFolder = path;
                    MessageBox.Show("Repository \"" + url + "\" wurde erfolgreich geklont.");
                    Close();
                };

                worker.RunWorkerAsync();
            }
        }

        private void SourceFolderSelectionForm_Load(object sender, EventArgs e) {
            Properties.Settings settings = Properties.Settings.Default;
            targetFolderSelectionComponent.Path = settings.RepositoryFolder;
        }

        private void SourceFolderSelectionForm_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Save();
        }
    }
}
