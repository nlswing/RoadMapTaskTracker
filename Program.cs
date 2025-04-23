class Program
{
    static void Main(string[] args)
    {
        Task newTask = new Task();
        List<Task> tasks = new List<Task>();

        if (args[0] == "add")
        {
            newTask.TaskName = args[1];
            newTask.TaskId = tasks.Count + 1;
            tasks.Add(newTask);
        }

        //Output
        Console.WriteLine($"Task added successfully (ID:{newTask.TaskId})");
    }
}

public class Task
{
    public string TaskName { get; set; }
    public int TaskId { get; set; }

}
