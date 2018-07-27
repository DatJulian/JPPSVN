using SharpSvn;
using System.Collections.ObjectModel;

namespace JPPSVN {
	internal static class SubversionHelper {
		public static SvnRevision MakeRevision(string revision) {
			return string.IsNullOrEmpty(revision) ? null : new SvnRevision(long.Parse(revision));
		}

		public static bool IsSVNFolder(SvnTarget path) {
			using(SvnClient client = new SvnClient()) {
				return client.GetInfo(
					path,
					new SvnInfoArgs() {ThrowOnError = false},
					out _
				);
			}
		}

		public static bool IsSVNFolder(string path) {
			return IsSVNFolder(SvnTarget.FromString(path));
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
