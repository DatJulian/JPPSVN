using System.ComponentModel;

namespace JPPSVN {
	internal class TaskDispatcher<TaskType> where TaskType : BackgroundWorker {
		public bool IsTaskRunning => Worker != null;

		public TaskType Worker { get; private set; }

		public void Run(TaskType w) {
			Worker = w;
			Worker.RunWorkerCompleted += (sender, e) => { Worker = null; };
			Worker.RunWorkerAsync();
		}
	}
}
