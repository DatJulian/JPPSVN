using SharpSvn;
using System.Collections.ObjectModel;

namespace JPPSVN {
    static class SubversionHelper {
        public static SvnRevision MakeRevision(string revision) {
            return string.IsNullOrEmpty(revision) ? null : new SvnRevision(long.Parse(revision));
        }

        public static bool IsSVNFolder(SvnTarget path) {
            Collection<SvnInfoEventArgs> svnInfo;
            using(SvnClient client = new SvnClient()) {
                return client.GetInfo(
                    path, 
                    new SvnInfoArgs() { ThrowOnError = false },
                    out svnInfo
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
    }
}
