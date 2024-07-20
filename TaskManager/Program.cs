using TaskManager.Services;
using TaskManager.Entities;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tarefa> tasks = new List<Tarefa>();
            tasks.Add(new Tarefa("012345678901234567890123456789012345678901234567890123456789"));
            tasks.Add(new Tarefa("012345678901234567890123456789012345678901234567890123456789"));
            tasks.Add(new Tarefa("012345678901234567890123456789012345678901234567890123456789"));
            tasks.Add(new Tarefa("012345678901234567890123456789012345678901234567890123456789"));
            Screen.PrintHomePage(tasks);
            

        }
    }
}
