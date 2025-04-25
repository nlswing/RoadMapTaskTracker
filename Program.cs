using System.Text.Json;

string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TaskTracker");
Directory.CreateDirectory(appDataPath);
string jsonFilePath = Path.Combine(appDataPath, "tasks.json");

Task newTask = new Task();
List<Task> tasks = new List<Task>();

if (args[0] == "add")
{
    newTask.TaskName = args[1];
    newTask.TaskId = tasks.Count + 1;
    tasks.Add(newTask);
}

var options = new JsonSerializerOptions();
options.WriteIndented = true;
string jsonString = JsonSerializer.Serialize(tasks, options);
File.WriteAllText(jsonFilePath, jsonString);

//Output
Console.WriteLine($"Task added successfully (ID:{newTask.TaskId})");

public class Task
{
    public string TaskName { get; set; }
    public int TaskId { get; set; }

}