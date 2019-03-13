using SharpSvn;

namespace JPPSVN {
	internal static class SubversionHelper {
		public static SvnRevision MakeRevision(string revision) {
			return string.IsNullOrEmpty(revision) ? null : new SvnRevision(long.Parse(revision));
		}

		public static bool IsSVNFolder(SvnClient client, string path) {
			return client.GetInfo(
				new SvnPathTarget(path), 
				new SvnInfoArgs() {ThrowOnError = false},
				out _
			);
		}
		
		public static bool UpdateDir(SvnClient client, string name, SvnDepth depth, out SvnUpdateResult result, string revision = null) {
			return client.Update(name, new SvnUpdateArgs {
				Revision = SubversionHelper.MakeRevision(revision),
				Depth = depth,
            IgnoreExternals = true,
				KeepDepth = true
         }, out result);
		}

		public static bool UpdateDir(SvnClient client, string name, SvnDepth depth, string revision = null) {
			return client.Update(name, new SvnUpdateArgs {
				Revision = SubversionHelper.MakeRevision(revision),
				Depth = depth,
				IgnoreExternals = true,
				KeepDepth = true
			});
		}
   }
}
