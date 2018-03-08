using System.ComponentModel;

namespace JPPSVN {
    class TaskDispatcher<TaskType> where TaskType : BackgroundWorker {
        TaskType worker = null;

        public bool IsTaskRunning {
            get { return worker != null; }
        }

        public TaskType Worker {
            get => worker;
        }

        public void Run(TaskType w) {
            worker = w;
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) => {
                worker = null;
            };
            worker.RunWorkerAsync();
        }
    }
}
