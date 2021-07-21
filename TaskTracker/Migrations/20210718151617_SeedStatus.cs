using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class SeedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 228, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 953, DateTimeKind.Utc).AddTicks(9494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 225, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 228, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "not yet started" },
                    { 2, "in progress" },
                    { 3, "completed" },
                    { 4, "past due" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 228, DateTimeKind.Utc).AddTicks(8163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 225, DateTimeKind.Utc).AddTicks(6431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 953, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 4, 51, 28, 228, DateTimeKind.Utc).AddTicks(9020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1838));
        }
    }
}
