using System;
using System.Windows.Forms;

namespace JPPSVN.forms {
	internal partial class SettingsForm : Form {
		public SettingsData SettingsData { get; }

		public string RepositoryFolder { get => repositoryFolderSelectionComponent.Path; set => repositoryFolderSelectionComponent.Path = value; }

		public string OutputFolder { get => outputFolderSelectionComponent.Path; set => outputFolderSelectionComponent.Path = value; }

		public string IDEAFolder { get => ideaFolderSelectionComponent.Path; set => ideaFolderSelectionComponent.Path = value; }

		public bool AutoFindIDEA { get => ideaFindAutomaticCheckBox.Checked; set => ideaFindAutomaticCheckBox.Checked = value; }

		public string RepositoryURL { get => repositoryURLTextBox.Text; set => repositoryURLTextBox.Text = value; }

		private int errors = 0;
		
      public SettingsForm(SettingsData settingsData) {
	      SettingsData = settingsData;

         InitializeComponent();
			
         outputFolderSelectionComponent.TextBox.Validated += (sender, args) => {
			   SetError(outputFolderSelectionComponent, string.IsNullOrWhiteSpace(OutputFolder) ? "Der Zielpfad darf nicht leer sein" : string.Empty);
	      };

         repositoryFolderSelectionComponent.TextBox.Validated += (sender, args) => {
		      SetError(repositoryFolderSelectionComponent, string.IsNullOrWhiteSpace(RepositoryFolder) ? "Der Repository-Pfad darf nicht leer sein." : string.Empty);
         };
      }

		private void SetError(Control control, string value) {
			if(value == errorProvider.GetError(control)) return;
			if(value == string.Empty)
				--errors;
			else
				++errors;
			errorProvider.SetError(control, value);
		}

		private void LoadFromSettings() {
			RepositoryFolder = SettingsData.RepositoryFolder;
			OutputFolder = SettingsData.OutputFolder;
			IDEAFolder = SettingsData.IDEAPath;
			AutoFindIDEA = SettingsData.AutoFindIDEA;
			RepositoryURL = SettingsData.RepositoryURL;
		}

		private void SaveToSettings() {
			SettingsData.RepositoryFolder = RepositoryFolder;
			SettingsData.OutputFolder = OutputFolder;
			SettingsData.IDEAPath = IDEAFolder;
			SettingsData.AutoFindIDEA = AutoFindIDEA;
			SettingsData.RepositoryURL = RepositoryURL;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			LoadFromSettings();

			if(AutoFindIDEA)
				IDEAFolder = IntelliJIDEA.FindPath();
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);

			if(DialogResult == DialogResult.OK) {
				SaveToSettings();
			}
		}

		private void okButton_Click(object sender, EventArgs e) {
			if(errors == 0) {
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			Close();
		}

		private void ideaFindAutomaticCheckBox_CheckedChanged(object sender, EventArgs e) {
			ideaFolderSelectionComponent.TextBox.ReadOnly = ideaFindAutomaticCheckBox.Checked;
			ideaFolderSelectionComponent.Button.Enabled = !ideaFindAutomaticCheckBox.Checked;
		}

      private void ideaFolderSelectionComponent_Paint(object sender, PaintEventArgs e) {

      }
   }
}
