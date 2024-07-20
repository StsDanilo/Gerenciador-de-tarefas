using TaskManager.Services;
using TaskManager.Entities;
using TaskManager.Enums;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
           
            while (ProgramExecution.IsRunning == true)
            {
                Screen.PrintHomePage(tarefas);

                try
                {
                    string[] entrada = Console.ReadLine().Split("-");
                    if (entrada.Length > 1)
                    {
                        Command command = new Command((CommandEnum)Enum.Parse(typeof(CommandEnum), entrada[0]), entrada[1]);
                        ExecuteCommand.Execute(command, tarefas);
                    } else
                    {
                        Command command = new Command((CommandEnum)Enum.Parse(typeof(CommandEnum), entrada[0]));
                        ExecuteCommand.Execute(command, tarefas);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
