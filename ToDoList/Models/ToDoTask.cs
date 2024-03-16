using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Enums;

namespace ToDoList.Models;

public class ToDoTask
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string Description { get; init; }
    public Priority Priority { get; init; }
    public State State { get; set; }
    public DateTime? OpenDate { get; set; }
    public DateTime? CloseDate { get; set; }
    public DateTime CreationDate { get; set; }
    public string? CreatorId { get; set; }
    public User? Creator { get; set; }
    public string? PerformerId { get; set; }
    public User? Performer { get; set; }

    public ToDoTask(
        string title, 
        string description, 
        Priority priority, 
        State state)
    {
        Title = title;
        Description = description;      
        Priority = priority;
        State = state;
        Id = Guid.NewGuid();
    }

    public bool Open()
    {
        if (State == State.New)
        {
            OpenDate = DateTime.UtcNow;
            State = State.Opened;

            return true;
        }

        return false;
    }

    public bool Close()
    {
        if (State == State.Opened)
        {
            CloseDate = DateTime.UtcNow;
            State = State.Closed;
            
            return true;
        }
        
        return false; 
    }

    public List<ActionType> AvailableActions()
    {
        return State switch
        {
            State.New => new List<ActionType> { ActionType.Open, ActionType.Details, ActionType.Delete }, 
            State.Opened => new List<ActionType> { ActionType.Close, ActionType.Details, ActionType.Take },
            State.Closed => new List<ActionType> { ActionType.Delete, ActionType.Details },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}