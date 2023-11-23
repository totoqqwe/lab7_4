using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler<ExampleTask, int> scheduler = new TaskScheduler<ExampleTask, int>();

            scheduler.AddTask(new ExampleTask("Task1"), 2);
            scheduler.AddTask(new ExampleTask("Task2"), 1);
            scheduler.AddTask(new ExampleTask("Task3"), 3);

            scheduler.ExecuteNext(task => Console.WriteLine($"Executing task: {task.Name}"));
        }
    }
}
