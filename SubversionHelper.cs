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

		public static bool Update(string path, string revision) {
			using(SvnClient client = new SvnClient()) {
				return client.Update(path, new SvnUpdateArgs {
					Revision = MakeRevision(revision),
					IgnoreExternals = true
				});
			}
		}

		public static bool UpdateDir(SvnClient client, string name, out SvnUpdateResult result, string revision = null) {
			return client.Update(name, new SvnUpdateArgs {
				Revision = SubversionHelper.MakeRevision(revision),
				Depth = SvnDepth.Infinity,
            IgnoreExternals = true,
				KeepDepth = true
         }, out result);
		}

		public static bool UpdateDirNonRecursive(SvnClient client, string name, string revision = null) {
			return client.Update(name, new SvnUpdateArgs {
				Revision = SubversionHelper.MakeRevision(revision),
            Depth = SvnDepth.Children,
				IgnoreExternals = true,
				KeepDepth = true
			});
		}
   }
}
