using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Services
{
    static class Screen
    {
        private static int FindBiggestTask(List<Tarefa> tarefas)
        {
            int biggestTaskLength = 0;
            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa.Name.Length > biggestTaskLength)
                {
                    biggestTaskLength = tarefa.Name.Length;
                }
            }
            return biggestTaskLength;
        }

        private static int RequiredWidth(List<Tarefa> tarefas)
        {
            int biggestTask = FindBiggestTask(tarefas);
            if (biggestTask <= 31)
            {
                return 40;
            }
            else if (biggestTask <= 51)
            {
                return biggestTask + 9;
            }
            else
            {
                return 60;
            }
        }

        private static void PrintDivisionLine(int width)
        {
            Console.Write("+");
            for (int i = 1; i <= width - 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }

        private static void PrintHeader(int width)
        {
            PrintDivisionLine(width);
            Console.Write("|  TASK MANAGER");
            for (int i = 1; i < width - 15; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.Write("+-+-");
            PrintDivisionLine(width - 4);
        }

        private static string ToShorterName(string name)
        {
            if (name.Length <= 31)
            {
                int emptyspace = 34 - name.Length;
                string aux = "";
                for (int i = 1; i <=  emptyspace; i++)
                {
                    aux = aux + " ";
                }
                return name + aux;
            }
            else if(name.Length <= 51)
            {
                return name + "   ";
            }
            else
            {
                return name.Substring(0, 51) + "...";
            }

        }

        private static void PrintTaskLines(List<Tarefa> tarefas)
        {
            foreach (Tarefa t in tarefas)
            {
                Console.Write("|");
                if (t.IsDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("V");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }
                Console.Write("|");
                int position = 1;
                Console.Write(position + "|");
                position++;
                Console.WriteLine(ToShorterName(t.Name) + "|");
            }
        }

        public static void PrintHomePage(List<Tarefa> tarefas)
        {
            int width = RequiredWidth(tarefas);
            PrintHeader(width);
            PrintTaskLines(tarefas);
            PrintDivisionLine(width);
            Console.WriteLine();
            Console.WriteLine("Enter command (if need help, write 'help'): ");

        }
    }
}
