using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Task
{
    public int TaskId { get; set; }
    public string TaskDescription { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TaskTracker");
        Directory.CreateDirectory(appDataPath);
        string jsonFilePath = Path.Combine(appDataPath, "tasks.json");

        List<Task> tasks = new List<Task>();

        // Load existing tasks if the file exists
        if (File.Exists(jsonFilePath))
        {
            string jsonTasks = File.ReadAllText(jsonFilePath);
            tasks = JsonSerializer.Deserialize<List<Task>>(jsonTasks) ?? new List<Task>();
        }

        if (args.Length > 0 && args[0] == "add" && args.Length > 1)
        {
            Task newTask = new Task
            {
                TaskId = tasks.Count + 1,
                TaskDescription = args[1]
            };
            tasks.Add(newTask);
            Console.WriteLine($"Task added successfully (ID:{newTask.TaskId})");
        }
        else if (args.Length > 2 && args[0] == "update")
        {
            int taskToUpdate = int.Parse(args[1]);
            var task = tasks.Find(t => t.TaskId == taskToUpdate);
            if (task != null)
            {
                task.TaskDescription = args[2];
                Console.WriteLine($"Task ID:{task.TaskId} updated successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(jsonFilePath, jsonString);
    }
}
