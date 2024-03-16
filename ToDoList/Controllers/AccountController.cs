using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Database;
using ToDoList.Mappers;
using ToDoList.Models;
using ToDoList.ViewModels.TaskVms;
using ToDoList.ViewModels.UserVms;

namespace ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ToDoListDbContext _db;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ToDoListDbContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm registerVm)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = registerVm.Email,
                UserName = registerVm.Email,
            };

            var identityResult = await _userManager.CreateAsync(user, registerVm.Password);
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Task");
            }
            
            foreach (var identityResultError in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, identityResultError.Description);
            }
        }

        return View(registerVm);
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginVm{ReturnUrl = returnUrl});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVm loginVm)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(loginVm.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    user,
                    loginVm.Password,
                    loginVm.RememberMe,
                    false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginVm.ReturnUrl) 
                        && Url.IsLocalUrl(loginVm.ReturnUrl))
                    {
                        return Redirect(loginVm.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Task");
                }
            }
            ModelState.AddModelError(string.Empty, "Неправильный логин и/или пароль");
        }

        return View(loginVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Task");
    }

    public IActionResult ShowAllCreatedTasks()
    {
        var userId = _db.Users.FirstOrDefault
            (user => user.Id == _userManager.GetUserId(User));

        ViewBag.UserId = userId.Id;

        var toDoTasks = _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer);
        
        var indexVm = new IndexViewModel()
        {
            Tasks = toDoTasks.Select(t => t.ToViewModel()).ToList()
        };

        return View(indexVm);
    }
    
    public IActionResult ShowAllTakenTasks()
    {
        var userId = _db.Users.FirstOrDefault
            (user => user.Id == _userManager.GetUserId(User));

        ViewBag.UserId = userId.Id;

        var toDoTasks = _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer);
        
        var indexVm = new IndexViewModel()
        {
            Tasks = toDoTasks.Select(t => t.ToViewModel()).ToList()
        };

        return View(indexVm);
    }

    public IActionResult ShowAllFreeTasks()
    {
        var toDoTasks = _db.Tasks
            .Include(task => task.Creator)
            .Include(task => task.Performer);
        
        var indexVm = new IndexViewModel()
        {
            Tasks = toDoTasks.Select(t => t.ToViewModel()).ToList()
        };

        return View(indexVm);
    }
}