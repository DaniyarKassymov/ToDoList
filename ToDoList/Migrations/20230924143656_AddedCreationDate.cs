using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1489fe7d-d9cd-4b16-9d08-245e7cfdbb98"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("54501933-0582-4b66-8ab6-77cb8a98a83b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("5ff23b53-dd21-464b-b869-454b475bcd5b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("97ce0cb2-b72c-456f-9a62-bf67bde3550e"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9c2d84dd-207a-4b2e-8b4f-c51881a3ea5c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d80d8437-8159-430f-a1b5-2bc6288a5955"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("da6efe5d-d8e5-47b6-a743-899695c5269b"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CloseDate", "CreationDate", "Description", "OpenDate", "PerformerName", "Priority", "State", "Title" },
                values: new object[,]
                {
                    { new Guid("06fecb40-ba73-40d8-8b04-5335d3f74712"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Создать модели", null, "Адилет", 1, 2, "Задача 6" },
                    { new Guid("1cb32819-c67c-49e0-bc91-88680e668fab"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Установить AD", null, "Теипжан", 1, 1, "Задача 3" },
                    { new Guid("3f6fa61a-2b33-460b-8ead-21de769fa62f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Создать БД", null, "Данияр", 2, 2, "Задача 5" },
                    { new Guid("75ed8e1d-3eb5-470c-bfa0-c7aaa252b85f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Подготовиться к контрольной", null, "Дархан", 0, 0, "Задача 2" },
                    { new Guid("7d6afeb8-a747-4453-ba7e-edd896fdb7af"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Создать контроллер", null, "Алихан", 1, 0, "Задача 7" },
                    { new Guid("aa6c6ed1-4f8b-4e82-928a-68583f0bcd51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Написать приложение", null, "Дамир", 0, 1, "Задача 1" },
                    { new Guid("ffb87d15-37ec-4e29-bdf3-60c1dc86d35a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Посмотреть вебинар", null, "Димаш", 2, 1, "Задача 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("06fecb40-ba73-40d8-8b04-5335d3f74712"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1cb32819-c67c-49e0-bc91-88680e668fab"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("3f6fa61a-2b33-460b-8ead-21de769fa62f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("75ed8e1d-3eb5-470c-bfa0-c7aaa252b85f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7d6afeb8-a747-4453-ba7e-edd896fdb7af"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("aa6c6ed1-4f8b-4e82-928a-68583f0bcd51"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ffb87d15-37ec-4e29-bdf3-60c1dc86d35a"));

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Tasks");

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
    }
}
