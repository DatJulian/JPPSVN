using Microsoft.Win32;
using System.Collections.Generic;

namespace JPPSVN {
	internal static class ProgramFinder {
        private const string UNINSTALL_REGFOLDER32 = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall",
            UNINSTALL_REGFOLDER64 = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";

        public static IEnumerable<RegistryKey> FilterSubKeysDisplayNameContains(RegistryKey key, string name) {
            foreach(var item in key.GetSubKeyNames()) {
                using(RegistryKey subkey = key.OpenSubKey(item)) {
                    string str = subkey.GetValue("DisplayName") as string;
                    if(str != null && str.Contains(name)) yield return subkey;
                }
            }
        }

        public static IEnumerable<RegistryKey> FindProgramKeys(string program) {
            using(RegistryKey key = Registry.LocalMachine.OpenSubKey(UNINSTALL_REGFOLDER32)) {
                if(key != null) foreach(RegistryKey skey in FilterSubKeysDisplayNameContains(key, program)) {
                    yield return skey;
                }
            }

            using(RegistryKey key = Registry.LocalMachine.OpenSubKey(UNINSTALL_REGFOLDER64)) {
                if(key != null) foreach(RegistryKey skey in FilterSubKeysDisplayNameContains(key, program)) {
                    yield return skey;
                }
            }
        }
    }
}
