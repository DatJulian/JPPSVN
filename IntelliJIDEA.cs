using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace JPPSVN {
	internal class IntelliJIDEA {
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
			return File.Exists(exe) ? exe : null;
		}

		public static string FindExe(bool autoFind, string orElse) {
			string path = autoFind ? FindPath() : orElse;
			return string.IsNullOrEmpty(path) ? null : FindExe(path);
		}

		public static bool IsValidIDEA(string path) {
			return !string.IsNullOrEmpty(path) && File.Exists(path);
		}

		public enum IDEAOpenFaileCause {
			Success,
			FileNotFound,
			FailedToStart
		}

		private readonly string ideaPath;

		public IntelliJIDEA(string path) {
			ideaPath = path;
		}

		public IDEAOpenFaileCause Open(string path) {
			if(!File.Exists(ideaPath)) return IDEAOpenFaileCause.FileNotFound;
			using(Process p = new Process {StartInfo = {Arguments = path, FileName = ideaPath}}) {
				try {
					if(p.Start()) return IDEAOpenFaileCause.Success;
				} catch(Win32Exception) { }
			}

			return IDEAOpenFaileCause.FailedToStart;
		}
	}
}
