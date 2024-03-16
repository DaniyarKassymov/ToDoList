using ToDoList.Enums;
using ToDoList.Models;
using ToDoList.ViewModels.TaskVms;

namespace ToDoList.Mappers;

public static class ToDoTaskMapper
{
    public static ToDoTaskVm ToViewModel(this ToDoTask task)
    {
        var actions = new List<ActionVm>();
        
        foreach (var availableAction in task.AvailableActions())
        {
            switch (availableAction)
            {
                case ActionType.Open:
                    actions.Add(new ActionVm{Title = "Открыть", ActionName = nameof(ActionType.Open)});
                    break;
                case ActionType.Close:
                    actions.Add(new ActionVm{Title = "Закрыть", ActionName = nameof(ActionType.Close)});
                    break;
                case ActionType.Details:
                    actions.Add(new ActionVm{Title = "Детали", ActionName = nameof(ActionType.Details)});
                    break;
                case ActionType.Delete:
                    actions.Add(new ActionVm{Title = "Удалить", ActionName = nameof(ActionType.Delete)});
                    break;
                case ActionType.Take:
                    actions.Add(new ActionVm{Title = "Взять", ActionName = nameof(ActionType.Take)});
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return new ToDoTaskVm()
        {
            Title = task.Title,
            State = task.State,
            Id = task.Id,
            Priority = task.Priority,
            Actions = actions,
            CreationDate = task.CreationDate,
            CreatorId = task.CreatorId,
            PerformerId = task.PerformerId
        };
    }

    public static ToDoTask FromAddVmToTask(AddTaskVm addTaskVm)
    {
        return new ToDoTask(
            $"{addTaskVm.Title}",
            $"{addTaskVm.Description}",
            addTaskVm.Priority,
            addTaskVm.State)
        {
            CreationDate = addTaskVm.CreationDate,
            CreatorId = addTaskVm.CreatorId
        };
    }

    public static DetailsVm ToDetailsVm(ToDoTask toDoTask)
    {
        var actions = new List<ActionVm>();
        
        foreach (var availableAction in toDoTask.AvailableActions())
        {
            switch (availableAction)
            {
                case ActionType.Open:
                    actions.Add(new ActionVm{Title = "Открыть", ActionName = nameof(ActionType.Open)});
                    break;
                case ActionType.Close:
                    actions.Add(new ActionVm{Title = "Закрыть", ActionName = nameof(ActionType.Close)});
                    break;
                case ActionType.Details:
                    actions.Add(new ActionVm{Title = "Детали", ActionName = nameof(ActionType.Details)});
                    break;
                case ActionType.Delete:
                    actions.Add(new ActionVm{Title = "Удалить", ActionName = nameof(ActionType.Delete)});
                    break;
                case ActionType.Take:
                    actions.Add(new ActionVm{Title = "Взять", ActionName = nameof(ActionType.Take)});
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return new DetailsVm
        {
            Priority = toDoTask.Priority,
            Description = toDoTask.Description,
            State = toDoTask.State,
            Id = toDoTask.Id,
            Title = toDoTask.Title,
            CloseDate = toDoTask.CloseDate,
            OpenDate = toDoTask.OpenDate,
            Actions = actions,
            CreationDate = toDoTask.CreationDate,
            CreatorName = toDoTask.Creator.Email,
            PerformerName = toDoTask.Performer?.Email,
            CreatorId = toDoTask.CreatorId,
            PerformerId = toDoTask.PerformerId
        };
    }
}