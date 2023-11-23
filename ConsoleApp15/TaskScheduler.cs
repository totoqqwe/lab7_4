using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class TaskScheduler<TTask, TPriority>
    {
        public delegate void TaskExecution(TTask task);

        private class TaskWithPriority
        {
            public TTask Task { get; }
            public TPriority Priority { get; }

            public TaskWithPriority(TTask task, TPriority priority)
            {
                Task = task;
                Priority = priority;
            }
        }

        private readonly PriorityQueue<TaskWithPriority> taskQueue = new PriorityQueue<TaskWithPriority>();

        public void AddTask(TTask task, TPriority priority)
        {
            taskQueue.Enqueue(new TaskWithPriority(task, priority));
        }

        public void ExecuteNext(TaskExecution executeTask)
        {
            if (taskQueue.Count > 0)
            {
                TaskWithPriority nextTask = taskQueue.Dequeue();
                executeTask(nextTask.Task);
            }
            else
            {
                Console.WriteLine("No tasks to execute.");
            }
        }
    }
}
