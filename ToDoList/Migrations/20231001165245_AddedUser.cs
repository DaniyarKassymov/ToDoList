using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PerformerName",
                table: "Tasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Tasks",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Tasks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerformerId",
                table: "Tasks",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CloseDate", "CreationDate", "CreatorId", "Description", "OpenDate", "PerformerId", "Priority", "State", "Title" },
                values: new object[,]
                {
                    { new Guid("0e21c3db-099b-4747-b7b2-c8cbf24c575e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Создать БД", null, null, 2, 2, "Задача 5" },
                    { new Guid("5abf8696-cab4-47a2-9137-37d1e3382fda"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Подготовиться к контрольной", null, null, 0, 0, "Задача 2" },
                    { new Guid("6f63744f-0618-42b7-b508-4a2d551989aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Создать контроллер", null, null, 1, 0, "Задача 7" },
                    { new Guid("b9d43e6e-cc42-4669-b1e7-9373f15d5bb7"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Посмотреть вебинар", null, null, 2, 1, "Задача 4" },
                    { new Guid("c5a81b1a-37eb-49c1-8411-a75380ff1273"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Установить AD", null, null, 1, 1, "Задача 3" },
                    { new Guid("c9e07971-e512-4a67-9490-976d1a6752f4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Написать приложение", null, null, 0, 1, "Задача 1" },
                    { new Guid("cb70aaa7-784a-4393-851c-f3ab111345d9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Создать модели", null, null, 1, 2, "Задача 6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PerformerId",
                table: "Tasks",
                column: "PerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreatorId",
                table: "Tasks",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_PerformerId",
                table: "Tasks",
                column: "PerformerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreatorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_PerformerId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PerformerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0e21c3db-099b-4747-b7b2-c8cbf24c575e"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("5abf8696-cab4-47a2-9137-37d1e3382fda"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("6f63744f-0618-42b7-b508-4a2d551989aa"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b9d43e6e-cc42-4669-b1e7-9373f15d5bb7"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c5a81b1a-37eb-49c1-8411-a75380ff1273"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c9e07971-e512-4a67-9490-976d1a6752f4"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cb70aaa7-784a-4393-851c-f3ab111345d9"));

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Tasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerformerName",
                table: "Tasks",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

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
    }
}
