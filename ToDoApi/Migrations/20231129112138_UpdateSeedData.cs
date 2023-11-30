using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "ToDos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4368), new DateTime(2023, 11, 30, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4371), new DateTime(2023, 11, 30, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4373), new DateTime(2023, 11, 30, 16, 21, 38, 757, DateTimeKind.Local).AddTicks(4372) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7363), new DateTime(2023, 11, 30, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7382), new DateTime(2023, 11, 30, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 29, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7424), new DateTime(2023, 11, 30, 11, 30, 19, 730, DateTimeKind.Local).AddTicks(7425) });
        }
    }
}
