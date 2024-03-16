using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Database;
using ToDoList.Enums;
using ToDoList.Mappers;
using ToDoList.Models;
using ToDoList.ViewModels.TaskVms;

namespace ToDoList.Controllers;

public class TaskController : Controller
{
    private readonly ToDoListDbContext _db;
    private readonly UserManager<User> _userManager;

    public TaskController(ToDoListDbContext db, UserManager<User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index(
        string? name,
        Priority? priority,
        string? description,
        State? state,
        DateTime? createdBefore,
        DateTime? createdAfter,
        TaskSortState stateSort = TaskSortState.NameAsc)
    {
        var toDoTasks = await _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer)
            .ToListAsync();

        var filterTasks = FilterTasks(toDoTasks, name, priority, description, state, createdBefore, createdAfter);

        ViewBag.NameSort = stateSort==TaskSortState.NameAsc ? TaskSortState.NameDesc : TaskSortState.NameAsc;
        ViewBag.PrioritySort = stateSort==TaskSortState.PriorityAsc ? TaskSortState.PriorityDesc : TaskSortState.PriorityAsc;
        ViewBag.StateSort = stateSort==TaskSortState.StateAsc ? TaskSortState.StateDesc : TaskSortState.StateAsc;
        ViewBag.CreationDateSort = stateSort==TaskSortState.CreationDateAsc ? TaskSortState.CreationDateDesc : TaskSortState.CreationDateAsc;

        filterTasks = SortTasks(filterTasks, stateSort);

        var indexVm = new IndexViewModel()
        {
            Tasks = filterTasks.Select(t => t.ToViewModel()).ToList()
        };

        var toDoTaskFiltered = new ToDoTaskFiltered()
        {
            Tasks = indexVm.Tasks,
            Name = name,
            Priority = priority,
            State = state,
            Description = description,
            CreatedAfter = createdAfter,
            CreatedBefore = createdBefore
        };

        var users = _userManager.Users.ToList();

        return View(toDoTaskFiltered);
    }

    private static List<ToDoTask> SortTasks(List<ToDoTask> toDoTasks, TaskSortState stateSort)
    {
        toDoTasks = stateSort switch
        {
            TaskSortState.NameAsc => toDoTasks.OrderBy(s => s.Title).ToList(),
            TaskSortState.NameDesc => toDoTasks.OrderByDescending(s => s.Title).ToList(),
            TaskSortState.PriorityAsc => toDoTasks.OrderBy(s => s.Priority).ToList(),
            TaskSortState.PriorityDesc => toDoTasks.OrderByDescending(s => s.Priority).ToList(),
            TaskSortState.StateAsc => toDoTasks.OrderBy(s => s.State).ToList(),
            TaskSortState.StateDesc => toDoTasks.OrderByDescending(s => s.State).ToList(),
            TaskSortState.CreationDateAsc => toDoTasks.OrderBy(s => s.CreationDate).ToList(),
            TaskSortState.CreationDateDesc => toDoTasks.OrderByDescending(s => s.CreationDate).ToList(),
            _ => throw new ArgumentOutOfRangeException(nameof(stateSort), stateSort, null)
        };

        return toDoTasks;
    }

    private static List<ToDoTask> FilterTasks(
        List<ToDoTask> toDoTasks,
        string? name,
        Priority? priority,
        string? description,
        State? state,
        DateTime? createdBefore,
        DateTime? createdAfter)
    {
        if (name is not null)
            toDoTasks = toDoTasks.Where(task => task.Title == name).ToList();

        if (priority is not null)
            toDoTasks = toDoTasks.Where(task => task.Priority == priority).ToList();

        if (description is not null)
            toDoTasks = toDoTasks.Where(task => task.Description.Contains(description)).ToList();

        if (state is not null)
            toDoTasks = toDoTasks.Where(task => task.State == state).ToList();

        if (createdAfter is not null)
            toDoTasks = toDoTasks.Where(task => task.CreationDate >= createdAfter).ToList();
        
        if (createdBefore is not null)
            toDoTasks = toDoTasks.Where(task => task.CreationDate <= createdBefore).ToList();

        return toDoTasks;
    }

    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var toDoTask = await _db.Tasks.FindAsync(id);

        var user = _db.Users.FirstOrDefault
            (user => user.Id == _userManager.GetUserId(User));

        if (toDoTask != null 
            && toDoTask.State != State.Opened
            && toDoTask.CreatorId == user.Id
            || User.IsInRole("admin"))
        {
            _db.Remove(toDoTask);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View("PermissionError");
    }

    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Open(Guid id)
    {
        var toDoTask = await _db.Tasks.FindAsync(id);
        
        var user = _db.Users.FirstOrDefault
            (user => user.Id == _userManager.GetUserId(User));

        if (toDoTask != null
            && toDoTask.CreatorId == user.Id
            || User.IsInRole("admin"))
        {
            if (toDoTask.Open())
                await _db.SaveChangesAsync();
            else
                ModelState.AddModelError("OpenError", "Задачу нельзя открыть");
            
            return RedirectToAction("Index");
        }

        return View("PermissionError");
    }
    
    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Close(Guid id)
    {
        var toDoTask = await _db.Tasks.FindAsync(id);

        var user = _db.Users.FirstOrDefault
            (user => user.Id == _userManager.GetUserId(User));
        
        if (toDoTask != null
            && toDoTask.PerformerId == user.Id
            || User.IsInRole("admin"))
        {
            if (toDoTask.Close())
                await _db.SaveChangesAsync();
            else
                ModelState.AddModelError("OpenError", "Задачу нельзя закрыть");
            
            return RedirectToAction("Index");
        }

        return View("PermissionError");
    }

    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public IActionResult Add()
    {
        var addTaskVm = new AddTaskVm()
        {
            CreationDate = DateTime.UtcNow,
            CreatorId = _userManager.GetUserId(User)
        };

        return View(addTaskVm);
    }

    [HttpPost]
    [Authorize(Roles = "admin, user")]
    public IActionResult Add(AddTaskVm addTaskVm)
    {
        if (addTaskVm != null)
        {
            _db.Tasks.Add(ToDoTaskMapper.FromAddVmToTask(addTaskVm));
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        return View("Add");
    }

    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public IActionResult Details(Guid id)
    {
        var toDoTask = _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer)
            .FirstOrDefault(task => task.Id == id);

        if (toDoTask != null)
        {
            var detailsVm = ToDoTaskMapper.ToDetailsVm(toDoTask);
            
            return View(detailsVm);
        }

        return NotFound();
    }

    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public IActionResult Take(Guid id)
    {
        var toDoTask = _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer)
            .FirstOrDefault(task => task.Id == id);

        if (toDoTask != null 
            && toDoTask.PerformerId == null)
        {
            toDoTask.PerformerId = _userManager.GetUserId(User);
            _db.Tasks.Update(toDoTask);
            _db.SaveChanges();
            var detailsVm = ToDoTaskMapper.ToDetailsVm(toDoTask);
            return RedirectToAction("Details", detailsVm);
        }

        return View("TakenStateError");
    }
}