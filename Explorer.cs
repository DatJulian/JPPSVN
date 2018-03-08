using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPPSVN {
    class Explorer {
        public static void Open(string path) {
            if(Directory.Exists(path))
                Process.Start(path);
        }
    }
}
