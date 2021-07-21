using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class UpdatedModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Employees_TaskId",
                table: "AssignedTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 545, DateTimeKind.Utc).AddTicks(6623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 542, DateTimeKind.Utc).AddTicks(6380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 904, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 545, DateTimeKind.Utc).AddTicks(7474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Employees_EmployeeId",
                table: "AssignedTasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Employees_EmployeeId",
                table: "AssignedTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(3664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 545, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 904, DateTimeKind.Utc).AddTicks(1851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 542, DateTimeKind.Utc).AddTicks(6380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(4609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 19, 36, 545, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Employees_TaskId",
                table: "AssignedTasks",
                column: "TaskId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
