using ToDoList.Enums;

namespace ToDoList.ViewModels.TaskVms;

public class ToDoTaskVm
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public required Priority Priority { get; init; }
    public required State State { get; init; }
    public DateTime CreationDate { get; init; }
    public string? CreatorId { get; set; }
    public string? PerformerId { get; set; }

    public required List<ActionVm> Actions { get; init; } = new();
}