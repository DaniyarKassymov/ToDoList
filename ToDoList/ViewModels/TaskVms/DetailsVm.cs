using ToDoList.Enums;

namespace ToDoList.ViewModels.TaskVms;

public class DetailsVm
{
    public Guid Id { get; set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Priority Priority { get; init; }
    public State State { get; set; }
    public DateTime? OpenDate { get; set; }
    public DateTime? CloseDate { get; set; }
    public DateTime CreationDate { get; set; }
    public string? CreatorName { get; set; }
    public string? PerformerName { get; set; }
    public string? CreatorId { get; set; }
    public string? PerformerId { get; set; }
    public required List<ActionVm> Actions { get; set; } = new();
}