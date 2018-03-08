using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPPSVN {
    class IntelliJIDEA {
        public static string FindPath() {
            foreach(RegistryKey key in ProgramFinder.FindProgramKeys("IntelliJ")) {
                return key.GetValue("InstallLocation") as string;
            }

            return null;
        }

        public static string FindExe(string basePath) {
            string exe = basePath + "\\bin\\idea64.exe";
            if(File.Exists(exe)) return exe;

            exe = basePath + "\\bin\\idea.exe";
            if(File.Exists(exe)) return exe;

            return null;
        }

        public enum IDEAOpenFaileCause {
            Success,
            FileNotFound,
            FailedToStart
        }

        private string ideaPath;

        public IntelliJIDEA(string path) {
            
            ideaPath = path;
        }

        public IDEAOpenFaileCause Open(string path) {
            if(!File.Exists(ideaPath)) return IDEAOpenFaileCause.FileNotFound;
            Process p = new Process();
            p.StartInfo.Arguments = path;
            p.StartInfo.FileName = ideaPath;
            try {
                if(p.Start()) return IDEAOpenFaileCause.Success;
            } catch(Win32Exception) {}
            return IDEAOpenFaileCause.FailedToStart;
        }
    }
}
