using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Enums;
using ToDoList.Models;
using ToDoList.Util;

namespace ToDoList.Database;

public class ToDoListDbContext : IdentityDbContext<User>
{
    public DbSet<ToDoTask>? Tasks { get; set; }
    public DbSet<User>? Users { get; set; }

    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(Constants.Properties.TitleMaxDescription);
        
        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(Constants.Properties.DescriptionMaxLength);

        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.Id);

        modelBuilder.Entity<ToDoTask>()
            .HasData(new List<ToDoTask>
            {
                new ToDoTask("Задача 1", "Написать приложение", Priority.High, State.Opened),
                new ToDoTask("Задача 2", "Подготовиться к контрольной", Priority.High, State.New),
                new ToDoTask("Задача 3", "Установить AD", Priority.Medium, State.Opened),
                new ToDoTask("Задача 4", "Посмотреть вебинар", Priority.Low, State.Opened),
                new ToDoTask("Задача 5", "Создать БД", Priority.Low, State.Closed),
                new ToDoTask("Задача 6", "Создать модели", Priority.Medium, State.Closed),
                new ToDoTask("Задача 7", "Создать контроллер", Priority.Medium, State.New),
            });

        modelBuilder.Entity<ToDoTask>()
            .HasOne(t => t.Creator)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatorId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ToDoTask>()
            .HasOne(t => t.Performer)
            .WithMany(u => u.TakenTasks)
            .HasForeignKey(t => t.PerformerId)
            .OnDelete(DeleteBehavior.SetNull);
            
        base.OnModelCreating(modelBuilder);
    }
}