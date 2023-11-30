using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class changeDataFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(783), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(797), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Deadline" },
                values: new object[] { new DateTime(2023, 11, 28, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(799), new DateTime(2023, 11, 29, 17, 28, 54, 836, DateTimeKind.Utc).AddTicks(799) });
        }
    }
}
