using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Enums;

namespace ToDoList.ViewModels.TaskVms;

public class AddTaskVm
{
    [Required(ErrorMessage = "*Это поле обязательно к заполнению")]
    [Remote("TaskCheckName", "Validation", ErrorMessage = "*Задача с таким именем уже существует")]
    public string? Title { get; init; }
    [Required(ErrorMessage = "*Это поле обязательно к заполнению")]
    public string? Description { get; init; }
    [Required(ErrorMessage = "*Это поле обязательно к заполнению")]
    public Priority Priority { get; init; }
    public State State { get; set; } = State.New;
    public DateTime CreationDate { get; set; }
    public string? CreatorId { get; set; }
}