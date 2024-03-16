using ToDoList.Enums;

namespace ToDoList.ViewModels.TaskVms;

public class ToDoTaskFiltered
{
    public List<ToDoTaskVm>? Tasks { get; set; }

    public Priority? Priority { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public State? State { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public DateTime? CreatedAfter { get; set; }
}