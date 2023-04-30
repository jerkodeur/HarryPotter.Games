namespace EventDiscovery
{
    internal class Boss
    {
        private DisplayMessage display;

        public Boss(DisplayMessage displayMessage)
        {
            display = displayMessage;
        }

        public void SaveCompletedTask(Task task)
        {
            display($"Je note que mon employé à bien terminée la tache {task}");
        }
    }
}
