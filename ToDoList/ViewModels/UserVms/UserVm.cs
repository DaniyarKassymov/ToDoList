using ToDoList.Models;

namespace ToDoList.ViewModels.UserVms;

public class UserVm
{
    public List<ToDoTask> CreatedTasks { get; set; } = new();
    public List<ToDoTask> TakenTasks { get; set; } = new();
}