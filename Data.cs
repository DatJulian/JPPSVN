namespace JPPSVN {
	public class Data {
		internal string User { get; set; }
		internal string UserName { get; set; }
		internal string Project { get; set; }
		internal string Revision { get; set; }

		public Data() { }

		public Data(string user, string userName, string project, string revision) {
			User = user;
			UserName = userName;
			Project = project;
			Revision = revision;
		}
	}
}
