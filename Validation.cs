using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPPSVN {
    static class Validation {
        public static bool IsValidRepositoryFolder(string path) {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path) && new SubversionHelper().IsSVNFolder(path);
        }
    }
}
