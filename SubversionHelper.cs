using SharpSvn;
using System;
using System.Collections.ObjectModel;

namespace JPPSVN {
    class SubversionHelper : IDisposable {
        private SvnClient client;

        public SvnClient Client => client;

        public SubversionHelper() {
            client = new SvnClient();
        }

        public static SvnRevision MakeRevision(string revision) {
            return string.IsNullOrEmpty(revision) ? null : new SvnRevision(long.Parse(revision));
        }

        public bool IsSVNFolder(SvnTarget path) {
            Collection<SvnInfoEventArgs> svnInfo;
            
            return client.GetInfo(
                path, 
                new SvnInfoArgs() /*{ ThrowOnError = false }*/,
                out svnInfo
            );;
        }

        public bool IsSVNFolder(string path) {
            return IsSVNFolder(SvnTarget.FromString(path));
        }

        public bool Checkout(SvnUriTarget source, string path, string revision, out SvnUpdateResult result) {
            SvnCheckOutArgs args = new SvnCheckOutArgs {
                Revision = MakeRevision(revision),
                IgnoreExternals = true
            };
            
            return client.CheckOut(source, path, args, out result);
        }

        public bool Checkout(string source, string path, string revision, out SvnUpdateResult result) {
            return Checkout(new SvnUriTarget(source), path, revision, out result);
        }

        public bool Checkout(string source, string path, out SvnUpdateResult result) {
            return Checkout(new SvnUriTarget(source), path, null, out result);
        }
        
        public bool Update(string path, string revision) {
            SvnUpdateArgs args = new SvnUpdateArgs {
                Revision = MakeRevision(revision),
                IgnoreExternals = true
            };

            return client.Update(path, args);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if(!disposedValue) {
                if(disposing) {
                    client.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SubversionHelper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
