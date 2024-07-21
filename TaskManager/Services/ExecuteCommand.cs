using TaskManager.Entities;
using TaskManager.Enums;

namespace TaskManager.Services
{
    internal class ExecuteCommand
    {
        public static void Execute(Command command, List<Tarefa> tarefas)
        {
            switch (command.CommandName)
            {
                case CommandEnum.Create:
                    Create(command, tarefas);
                    break;
                case CommandEnum.Edit:
                    Edit(command, tarefas);
                    break;
                case CommandEnum.Delete:
                    Delete(command, tarefas);
                    break;
                case CommandEnum.Help:
                    Help();
                    Console.ReadLine();
                    break;
                case CommandEnum.Status:
                    Status(command, tarefas);
                    break;
                case CommandEnum.End:
                    End();
                    break;
                case CommandEnum.Expand:
                    Expand(command, tarefas);
                    break;
                default:
                break;

            }
        }

        private static void Create(Command command, List<Tarefa> tarefas)
        {
            tarefas.Add(new Tarefa(command.Parameter));
        }
        private static void Edit(Command command, List<Tarefa> tarefas)
        {
            Tarefa task = tarefas[int.Parse(command.Parameter) - 1];
            Console.WriteLine("Write the new task: ");
            task.Name = Console.ReadLine();
        }
        private static void Delete(Command command, List<Tarefa> tarefas)
        {
            tarefas.Remove(tarefas[int.Parse(command.Parameter) - 1]);
        }
        private static void Help()
        {
            Console.WriteLine("Command List:");
            Console.WriteLine("    Create-task : Create a new task");
            Console.WriteLine("    Edit-position : Edit a existent task" );
            Console.WriteLine("    Delete-position : Delete the task");
            Console.WriteLine("    Status-position : Change task status");
            Console.WriteLine("    End : End the program");
        }
        private static void Status(Command command, List<Tarefa> tarefas)
        {
            Tarefa task = tarefas[int.Parse(command.Parameter) - 1];
            if (task.IsDone)
            {
                task.IsDone = false;
            }
            else
            {
                task.IsDone = true;
            }
        }
        private static void End()
        {
            ProgramExecution.IsRunning = false;
        }

        private static void Expand(Command command, List<Tarefa> tarefas)
        {
            Tarefa task = tarefas[int.Parse(command.Parameter) - 1];
            Screen.PrintExtendedTask(task, tarefas);
            Console.ReadLine();
        }
    }
}
