using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JPPSVN.forms {
	public sealed partial class ProjectForm : Form {
		private readonly TaskDispatcher taskDispatcher;
		private Process explorerProcess;

		internal Data Data { get; }
		internal string Folder { get; }
		internal IntelliJIDEA IntelliJ { get; }
		internal string UpdatedRevision { get; }

		internal ProjectForm(Data data, string folder, IntelliJIDEA intelliJ, string updatedRevision) {
			Data = data;
			Folder = folder;
			IntelliJ = intelliJ;
			UpdatedRevision = updatedRevision;
			taskDispatcher = new TaskDispatcher();
			InitializeComponent();
			userNameTextBox.Text = Data.UserName;
			userTextBox.Text = Data.User;
         projectTextBox.Text = Data.Project;
			revisionTextBox.Text = UpdatedRevision;
			openIntelliJButton.Enabled = IntelliJ != null;

         Text = MakeTitle(Data);
		}

		private void openIntelliJButton_Click(object sender, EventArgs e) {
			IntelliJ.Open(Folder);
		}

		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

      private void openExplorerButton_Click(object sender, EventArgs e) {
			if(explorerProcess != null) {
		      if(!explorerProcess.HasExited && explorerProcess.Responding) {
			      SetForegroundWindow(explorerProcess.MainWindowHandle);
			      return;
		      }
				explorerProcess.Dispose();
			}
	      explorerProcess = Explorer.Open(Folder);
      }

      private void Cleanup() {
	      if(taskDispatcher.IsTaskRunning)
		      return;

			BackgroundWorker task = new BackgroundWorker();
			task.DoWork += (o, ev) => {
				if(Directory.Exists(Folder)) DirectoryUtil.DeleteDirectory(Folder);
			};
			task.RunWorkerCompleted += (snder, es) => { Close(); };
			taskDispatcher.Run(task);
		}

		private static string MakeTitle(Data data) {
         return data.UserName + " (" + data.Project + ')';
		}

		private void cleanupButton_Click(object sender, EventArgs e) {
			Cleanup();
		}

      private void ProjectForm_FormClosing(object sender, FormClosingEventArgs e) {
	      explorerProcess?.Dispose();
      }
   }
}
