using System;
using System.IO;

namespace JPPSVN {
	public static class DirectoryUtil {
		private static void CopyFiles(DirectoryInfo directory, string destDirName) {
			foreach (FileInfo file in directory.EnumerateFiles()) {
				string temppath = Path.Combine(destDirName, file.Name);
				file.CopyTo(temppath, true);
			}
      }

		private static void CopySubDirectories(DirectoryInfo directory, string destDirName, bool copySubDirs, Predicate<string> topLevelFolderPredicate) {
         foreach (DirectoryInfo subdir in directory.EnumerateDirectories()) {
	         if(!topLevelFolderPredicate(subdir.Name))
		         continue;
				string temppath = Path.Combine(destDirName, subdir.Name);
				Copy(subdir, temppath, copySubDirs, s => true);
			}
      }

		private static void Copy(DirectoryInfo dir, string destDirName, bool copySubDirs, Predicate<string> topLevelFolderPredicate) {
         // If the destination directory doesn't exist, create it.
			DirectoryInfo destination = new DirectoryInfo(destDirName);
			if (!destination.Exists)
				destination.Create();

         CopyFiles(dir, destDirName);

			// If copying subdirectories, copy them and their contents to new location.
			if(!copySubDirs) return;
			CopySubDirectories(dir, destDirName, copySubDirs, topLevelFolderPredicate);
		}

      public static void CopyIgnoreNotExists(string sourceDirName, string destDirName, bool copySubDirs, Predicate<string> topLevelFolderPredicate) {
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);

			if(dir.Exists)
				Copy(dir, destDirName, copySubDirs, topLevelFolderPredicate);
		}

		public static void CopyIgnoreNotExists(string sourceDirName, string destDirName, bool copySubDirs) {
			CopyIgnoreNotExists(sourceDirName, destDirName, copySubDirs, s => true);
		}

      public static void DeleteDirectory(string path) {
			foreach(string directory in Directory.GetDirectories(path)) {
				DeleteDirectory(directory);
			}

			try {
				Directory.Delete(path, true);
			} catch(IOException) {
				Directory.Delete(path, true);
			} catch(UnauthorizedAccessException) {
				Directory.Delete(path, true);
			}
		}
	}
}
