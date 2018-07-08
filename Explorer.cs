using System.Diagnostics;
using System.IO;

namespace JPPSVN {
	internal class Explorer {
        public static void Open(string path) {
            if(Directory.Exists(path))
                Process.Start(path);
        }
    }
}
