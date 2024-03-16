using System.ComponentModel.DataAnnotations;

namespace ToDoList.Enums;

public enum State
{
    [Display(Name = "Новый")]
    New,
    [Display(Name = "Открытый")]
    Opened,
    [Display(Name = "Закрытый")]
    Closed
}