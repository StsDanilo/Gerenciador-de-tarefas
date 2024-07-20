using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    internal class Tarefa
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int TaskLength { get; set; }

        public Tarefa(string name)
        {
            Name = name;
            IsDone = false;
            TaskLength = name.Length + 5;
        }

    }
}
