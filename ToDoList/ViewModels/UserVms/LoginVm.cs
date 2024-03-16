using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModels.UserVms;

public class LoginVm
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; }
    public bool RememberMe { get; init; }
    public string? ReturnUrl { get; init; }
}