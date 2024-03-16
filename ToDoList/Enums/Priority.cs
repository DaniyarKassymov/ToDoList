using System.ComponentModel.DataAnnotations;

namespace ToDoList.Enums;

public enum Priority
{
    [Display(Name = "Высокий")]
    High,
    [Display(Name = "Средний")]
    Medium,
    [Display(Name = "Низкий")]
    Low
}