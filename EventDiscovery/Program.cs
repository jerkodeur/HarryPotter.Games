using EventDiscovery;

Worker worker = new(Console.WriteLine, "Yusuf");
Worker worker_2 = new(Console.WriteLine, "Khaoula");
Boss boss = new(Console.WriteLine);

EventDiscovery.Task task = new()
{
    Id = 1,
    Duration = 2,
    Label = "Coder une fonction de calcul",
};

EventDiscovery.Task task_2 = new()
{
    Id = 1,
    Duration = 2,
    Label = "Je teste la fonction de calcul fonction de calcul",
};

// Fonction qui sera exécutée lorsque la tâche sera terminée
void CompletedTask(EventDiscovery.Task task)
{
    Console.WriteLine($"{task} a été terminée !!!");
}

// Autre fonction qui sera exécutée lorsque la tâche sera terminée
void CompletedTask2(EventDiscovery.Task task2)
{
    Console.WriteLine($"{task2} a été terminée!!!");
}

// Je m'abonne à la tâche et exécute mes fonction une fois la tache terminée
worker.TaskCompleted += CompletedTask;
worker.TaskCompleted += boss.SaveCompletedTask;
worker_2.TaskCompleted += CompletedTask2;
worker_2.TaskCompleted += boss.SaveCompletedTask;

worker.Execute(task);
worker_2.Execute(task_2);

// Je me désabonne (Important)
worker.TaskCompleted -= CompletedTask;
worker.TaskCompleted -= boss.SaveCompletedTask;
worker.TaskCompleted -= worker_2.Execute;
worker_2.TaskCompleted -= CompletedTask;
worker_2.TaskCompleted -= boss.SaveCompletedTask;