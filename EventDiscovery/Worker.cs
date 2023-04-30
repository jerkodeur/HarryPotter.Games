namespace EventDiscovery
{
    internal class Worker
    {
        private DisplayMessage display;

        public string lastname { get; set; } = String.Empty;
        public event Action<Task>? TaskCompleted;

        public Worker(DisplayMessage display) => this.display = display ?? throw new ArgumentNullException(nameof(display));

        public Worker(DisplayMessage display, string lastname) : this(display)
        {
            this.lastname = lastname;
        }

        public void Work(Task task)
        {
            display($"{lastname}, je travaille sur la tâche {task}");
        }

        public void Execute(Task task) 
        {
            display($"{lastname}, J'ai bien fini ma tâche {task.Label}");
            TaskCompleted?.Invoke(task);
        }
    }
}
