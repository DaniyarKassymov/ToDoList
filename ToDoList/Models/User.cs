using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models;

public class User : IdentityUser
{
    public List<ToDoTask> CreatedTasks { get; set; } = new();
    public List<ToDoTask> TakenTasks { get; set; } = new();
}