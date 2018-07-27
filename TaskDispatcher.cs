using System.ComponentModel;

namespace JPPSVN {
	internal class TaskDispatcher {
		public bool IsTaskRunning => Worker != null;

		public BackgroundWorker Worker { get; private set; } = null;

		public void Run(BackgroundWorker w) {
			Worker = w;
			Worker.RunWorkerCompleted += (sender, e) => { Worker = null; };
			Worker.RunWorkerAsync();
		}
	}
}
