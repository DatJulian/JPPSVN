using System;
using System.Windows.Forms;

namespace JPPSVN {
	public partial class Settings : Form {
		public string RepositoryFolder { get => repositoryFolderSelectionComponent.Path; set => repositoryFolderSelectionComponent.Path = value; }

		public string OutputFolder { get => outputFolderSelectionComponent.Path; set => outputFolderSelectionComponent.Path = value; }

		public string IDEAFolder { get => ideaFolderSelectionComponent.Path; set => ideaFolderSelectionComponent.Path = value; }

		public bool AutoFindIDEA { get => ideaFindAutomaticCheckBox.Checked; set => ideaFindAutomaticCheckBox.Checked = value; }

		public string RepositoryURL { get => repositoryURLTextBox.Text; set => repositoryURLTextBox.Text = value; }


      public Settings() {
			InitializeComponent();
		}

		private void LoadFromSettings(Properties.Settings settings) {
			RepositoryFolder = settings.RepositoryFolder;
			OutputFolder = settings.OutputFolder;
			IDEAFolder = settings.IDEAPath;
			AutoFindIDEA = settings.AutoFindIDEA;
			RepositoryURL = settings.RepositoryURL;
		}

		private void SaveToSettings(Properties.Settings settings) {
			settings.RepositoryFolder = RepositoryFolder;
			settings.OutputFolder = OutputFolder;
			settings.IDEAPath = IDEAFolder;
			settings.AutoFindIDEA = AutoFindIDEA;
			settings.RepositoryURL = RepositoryURL;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			Properties.Settings settings = Properties.Settings.Default;

			LoadFromSettings(settings);

			if(AutoFindIDEA)
				IDEAFolder = IntelliJIDEA.FindPath();
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);

			if(DialogResult == DialogResult.OK) {
				Properties.Settings settings = Properties.Settings.Default;

				SaveToSettings(settings);

				settings.Save();
			}
		}

		private bool ValidateValues() {
			return Validation.Settings.MessageBoxIsValidRepositoryFolder(RepositoryFolder)
			       && Validation.Settings.MessageBoxIsValidOutputFolder(OutputFolder)
			       && Validation.Settings.MessageBoxIsValidIDEA(AutoFindIDEA, IDEAFolder);
		}

		private void okButton_Click(object sender, EventArgs e) {
			if(ValidateValues()) {
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
	}
}
