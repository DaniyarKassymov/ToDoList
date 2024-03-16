using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModels.UserVms;

public class RegisterVm
{
    [Required(ErrorMessage = "Поле обязательно")]
    [EmailAddress(ErrorMessage = "Неверный формат")]
    public required string Email { get; set; }
    [Required(ErrorMessage = "Поле обязательно")]
    public required int Age { get; set; }
    [Required(ErrorMessage = "Поле обязательно")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "Поле обязательно")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    [Required(ErrorMessage = "Поле обязательно")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public required string ConfirmPassword { get; set; }
}