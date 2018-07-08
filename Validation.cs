using System.IO;
using System.Windows.Forms;

namespace JPPSVN {
	namespace Validation {
		internal static class Settings {
			public static bool MessageBoxIsWhiteSpace(string str, string name) {
				if (string.IsNullOrWhiteSpace(str)) {
					MessageBox.Show(name + " darf nicht leer sein.");
					return false;
				}

				return true;
			}

			public static bool MessageBoxNotExists(string path, string name) {
				if (!Directory.Exists(path)) {
					MessageBox.Show(name + " existiert nicht.");
					return false;
				}

				return true;
			}

			public static bool MessageBoxIsSVNRepo(string path) {
				if (!SubversionHelper.IsSVNFolder(path)) {
					MessageBox.Show(path + " ist keine SVN Repository.");
					return false;
				}

				return true;
			}

			public static bool MessageBoxIsWhiteSpaceOrNotExists(string path, string name) {
				return MessageBoxIsWhiteSpace(path, name) && MessageBoxNotExists(path, name);
			}

			public static bool MessageBoxIsValidIDEA(bool autoFind, string ideapath) {
				string path;
				if (autoFind) {
					path = IntelliJIDEA.FindPath();
					if (path == null) {
						MessageBox.Show("IntelliJ konnte nicht automatisch gefunden werden.");
						return false;
					}
				} else {
					path = ideapath;
					if (!MessageBoxIsWhiteSpace(path, "IntelliJ-Pfad"))
						return false;
				}

				string exe = IntelliJIDEA.FindExe(path);
				if (!File.Exists(exe)) {
					MessageBox.Show("IntelliJ-Executable konnte nicht in \"" + path + "\" gefunden werden.");
					return false;
				}

				return true;
			}

			public static bool MessageBoxIsValidOutputFolder(string path) {
				return MessageBoxIsWhiteSpace(path, "Zielordner");
			}

			public static bool MessageBoxIsValidRepositoryFolder(string path) {
				return MessageBoxIsWhiteSpaceOrNotExists(path, "Repository-Ordner") && MessageBoxIsSVNRepo(path);
			}
		}
	}
}
