using Microsoft.AspNetCore.Mvc;
using ToDoList.Database;

namespace ToDoList.Controllers;

public class ValidationController : Controller
{
    private readonly ToDoListDbContext _db;

    public ValidationController(ToDoListDbContext db)
    {
        _db = db;
    }

    public bool TaskCheckName(string name)
    {
        return !_db.Tasks.Any(t => t.Title == name);
    }
}