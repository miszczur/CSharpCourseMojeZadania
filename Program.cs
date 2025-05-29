
class Program
{

    private List<string> tasks = new List<string>();

    public void AddTask(string task)
    {
        // TODO: Uzupełnij implementację metody AddTask, aby dodawała nowe zadanie do listy.
        tasks.Add(task);
    }

    public void RemoveTask(string task)
    {
        // TODO: Uzupełnij implementację metody RemoveTask, aby usuwała zadanie z listy, jeśli istnieje.
        tasks.Remove(task);
    }

    public List<string> GetTasks()
    {
        // TODO: Uzupełnij implementację metody GetTasks, aby zwracała listę wszystkich zadań.
        return tasks;
    }
    static void Main(string[] args)
    {

        //Zadania będą na oddzielnych branchach
    }
}


