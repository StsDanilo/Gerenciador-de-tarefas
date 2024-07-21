using TaskManager.Entities;

namespace TaskManager.Services
{
    static class Screen
    {
        // função auxiliar para encontrar a tarefa de maior nome
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

        // função auxiliar para saber qual a largura necessária do layout
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

        //função auxiliar para imprimir linhas no layout
        private static void PrintDivisionLine(int width, int type)
        {
            if (type == 1)
            {
                Console.Write("+");
                PrintRepeatedCharacters(width - 2, '-');
                Console.WriteLine("+");
            }
            else if (type == 2)
            {
                Console.Write("+-+-+");
                PrintRepeatedCharacters(width - 6, '-');
                Console.WriteLine("+");
            }

        }

        // função auxiliar para imprimir o cabeçario
        private static void PrintHeader(int width)
        {
            PrintDivisionLine(width, 1);
            Console.Write("|  TASK MANAGER");
            PrintRepeatedCharacters(width - 16, ' ');
            Console.WriteLine("|");
            PrintDivisionLine(width, 2);
        }

        // função para reduzir o tamanho do nome caso ultrapasse o máximo
        private static string ToShorterName(string name)
        {
            return name.Substring(0, 51) + "...";
        }

        // função auxiliar para imprimir espaços vazios até o fim da linha
        private static void PrintRepeatedCharacters(int repetition, char c)
        {
            for (int i = 1; i <= repetition; i++)
            {
                Console.Write(c);
            }
        }

        //função auxiliar para imprimir as linhas de tarefas
        private static void PrintTaskLines(List<Tarefa> tarefas)
        {
            bool haveABiggerNumber = false;
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
                Console.Write((tarefas.IndexOf(t) + 1) + "|");

                string name = t.Name;
                int biggerTask = FindBiggestTask(tarefas);

                if (name.Length < biggerTask)
                {
                    haveABiggerNumber = true;
                }
                else
                {
                    haveABiggerNumber = false;
                }




                if (!haveABiggerNumber)
                {
                    if (name.Length <= 31)
                    {
                        // é o maior número e é menor que o tamanho mínimo
                        Console.Write(name);
                        int diference = 34 - name.Length;
                        PrintRepeatedCharacters(diference, ' ');
                    }
                    else if (name.Length <= 51)
                    {
                        //é o maior número e está entre o tamanho máximo e mínimo
                        Console.Write(name + "   ");
                    }
                    else
                    {
                        //é o maior número e é maior que o tamanho máximo
                        Console.Write(ToShorterName(name));
                    }
                }
                else if (biggerTask <= 31)
                {
                    //não é o maior número e o maior número é menor que o tamanho mínimo
                    Console.Write(name);
                    int diference = 34 - name.Length;
                    PrintRepeatedCharacters(diference, ' '); 
                }
                else if (biggerTask <= 51)
                {
                    //não é o maior número e o maior número está entre o tamanho mínimo e o máximo
                    Console.Write(name);
                    int diference = biggerTask + 3 - name.Length;
                    PrintRepeatedCharacters(diference, ' ');
                }
                else
                {
                    //tem um número maior e ele é do tamanho 
                    Console.Write(name);
                    int diference = 54 - name.Length;
                    PrintRepeatedCharacters(diference, ' ');
                }

                Console.WriteLine("|");
            }
        }

        //função para imprimir a pagina principal
        public static void PrintHomePage(List<Tarefa> tarefas)
        {
            Console.Clear();

            int width = RequiredWidth(tarefas);
            PrintHeader(width);
            PrintTaskLines(tarefas);
            PrintDivisionLine(width, 2);
            Console.WriteLine();
            Console.WriteLine("Enter command (if need help, write 'Help'): ");

        }
    }
}
