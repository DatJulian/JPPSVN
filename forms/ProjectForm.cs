using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JPPSVN.forms {
	public sealed partial class ProjectForm : Form {
		internal class ProjectFormArgs {
			internal Data Data { get; }
			internal string Folder { get; }
			internal IntelliJIDEA IntelliJ { get; }
			internal string UpdatedRevision { get; }

			public ProjectFormArgs(Data data, string folder, IntelliJIDEA intelliJ, string updatedRevision) {
				Data = data;
				Folder = folder;
				IntelliJ = intelliJ;
				UpdatedRevision = updatedRevision;
			}
		}

		private readonly TaskDispatcher taskDispatcher;
		private Process explorerProcess;

		internal ProjectFormArgs Args { get; }

		internal ProjectForm(ProjectFormArgs args) {
			Args = args;
			taskDispatcher = new TaskDispatcher();
			InitializeComponent();
			userNameTextBox.Text = args.Data.UserName;
			userTextBox.Text = args.Data.User;
         projectTextBox.Text = args.Data.Project;
			revisionTextBox.Text = args.UpdatedRevision;

         Text = MakeTitle(Args.Data);
		}

		private void openIntelliJButton_Click(object sender, EventArgs e) {
			if(Args.IntelliJ == null) {
				MessageBox.Show("IntelliJ konnte nicht gefunden werden.");
				return;
			}
			Args.IntelliJ.Open(Args.Folder);
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
	      explorerProcess = Explorer.Open(Args.Folder);
      }

      private void Cleanup() {
	      if(taskDispatcher.IsTaskRunning)
		      return;

			BackgroundWorker task = new BackgroundWorker();
			task.DoWork += (o, ev) => {
				if(Directory.Exists(Args.Folder)) DirectoryUtil.DeleteDirectory(Args.Folder);
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
