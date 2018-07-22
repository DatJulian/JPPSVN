namespace JPPSVN {
	internal class SettingsData {
		public string RepositoryFolder { get; set; }

		public string IDEAPath { get; set; }

		public string RepositoryURL { get; set; }

		public string OutputFolder { get; set; }

		public bool AutoFindIDEA { get; set; }

		public SettingsData(SettingsData settings) {
			RepositoryFolder = settings.RepositoryFolder;
			AutoFindIDEA = settings.AutoFindIDEA;
			IDEAPath = settings.IDEAPath;
			RepositoryURL = settings.RepositoryURL;
			OutputFolder = settings.OutputFolder;
      }
      
		public SettingsData(Properties.Settings settings) {
			RepositoryFolder = settings.RepositoryFolder;
			AutoFindIDEA = settings.AutoFindIDEA;
			IDEAPath = settings.IDEAPath;
			RepositoryURL = settings.RepositoryURL;
			OutputFolder = settings.OutputFolder;
		}

		public void Save(Properties.Settings settings) {
			settings.RepositoryFolder = RepositoryFolder;
			settings.AutoFindIDEA = AutoFindIDEA;
			settings.IDEAPath = IDEAPath;
			settings.RepositoryURL = RepositoryURL;
			settings.OutputFolder = OutputFolder;
		}
	}
}
