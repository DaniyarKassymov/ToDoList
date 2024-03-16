using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    PerformerName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    OpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CloseDate", "Description", "OpenDate", "PerformerName", "Priority", "State", "Title" },
                values: new object[,]
                {
                    { new Guid("1489fe7d-d9cd-4b16-9d08-245e7cfdbb98"), null, "Создать контроллер", null, "Алихан", 1, 0, "Задача 7" },
                    { new Guid("54501933-0582-4b66-8ab6-77cb8a98a83b"), null, "Установить AD", null, "Теипжан", 1, 1, "Задача 3" },
                    { new Guid("5ff23b53-dd21-464b-b869-454b475bcd5b"), null, "Создать модели", null, "Адилет", 1, 2, "Задача 6" },
                    { new Guid("97ce0cb2-b72c-456f-9a62-bf67bde3550e"), null, "Написать приложение", null, "Дамир", 0, 1, "Задача 1" },
                    { new Guid("9c2d84dd-207a-4b2e-8b4f-c51881a3ea5c"), null, "Посмотреть вебинар", null, "Димаш", 2, 1, "Задача 4" },
                    { new Guid("d80d8437-8159-430f-a1b5-2bc6288a5955"), null, "Подготовиться к контрольной", null, "Дархан", 0, 0, "Задача 2" },
                    { new Guid("da6efe5d-d8e5-47b6-a743-899695c5269b"), null, "Создать БД", null, "Данияр", 2, 2, "Задача 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
