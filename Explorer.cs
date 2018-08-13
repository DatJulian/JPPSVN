using System.Diagnostics;

namespace JPPSVN {
	internal class Explorer {
		public static Process Open(string path) {
			var process = new Process {
				StartInfo = new ProcessStartInfo("explorer.exe", path)
			};
			process.Start();
			return process;
//         return Process.Start(path);
		}
	}
}
