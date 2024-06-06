using System.IO;
using System.Net;
using Newtonsoft.Json;
using WpfApp6.Models;

namespace WpfApp6.Controllers;

public class TaskController
{
    private IList<DayTask> _tasks = new List<DayTask>();
    
    public TaskController()
    {
        OpenFile();
    }

    private void OpenFile()
    {
        if (!File.Exists("task.json"))
            Save();
        
        var jsonOpen = File.ReadAllText("task.json");
        _tasks = JsonConvert.DeserializeObject<IList<DayTask>>(jsonOpen) ?? new List<DayTask>();

    }

    public void AddNewTask(DayTask task)
    {
        _tasks.Add(task);
        Save();
    }

    public IEnumerable<DayTask> Get(DateOnly dateOnly)
    {
        return from task in _tasks where task.Date == dateOnly select task;
    }

    public void DeleteTask(string id)
    {
        var task = _tasks.FirstOrDefault(x => x.Id.ToString() == id);
        
        if(task is null)
            return;
        _tasks.Remove(task);
        Save();
    }

    private void Save()
    {
        string json = JsonConvert.SerializeObject(_tasks);
        File.WriteAllText("task.json", json);
        
    }
}