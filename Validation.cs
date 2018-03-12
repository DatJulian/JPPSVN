using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
    static class Validation {
        public static bool IsValidRepositoryFolder(string path) {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path) && SubversionHelper.IsSVNFolder(path);
        }
    }
}
