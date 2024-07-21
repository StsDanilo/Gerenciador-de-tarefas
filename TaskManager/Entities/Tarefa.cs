
namespace TaskManager.Entities
{
    internal class Tarefa
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }

        public Tarefa(string name)
        {
            Name = name;
            IsDone = false;
        }

    }
}
