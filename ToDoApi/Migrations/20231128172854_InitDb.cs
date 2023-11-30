using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Completed", "CreatedDate", "Deadline", "Description", "Name" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(783), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(791), "", "Помыть полы" },
                    { 2, false, new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(797), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(798), "Купить яблоки и бананы", "Сходить в магазин" },
                    { 3, true, new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(799), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(799), "", "Вынести мусор" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
