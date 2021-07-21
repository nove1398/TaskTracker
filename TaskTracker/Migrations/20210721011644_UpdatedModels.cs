using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Employees_EmployeeId",
                table: "AssignedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Tasks_TaskId",
                table: "AssignedTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(3664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 904, DateTimeKind.Utc).AddTicks(1851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 953, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(4609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Employees_TaskId",
                table: "AssignedTasks",
                column: "TaskId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Tasks_TaskId",
                table: "AssignedTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Employees_TaskId",
                table: "AssignedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Tasks_TaskId",
                table: "AssignedTasks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 907, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 953, DateTimeKind.Utc).AddTicks(9494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 21, 1, 16, 43, 904, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AssignedTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 18, 15, 16, 16, 957, DateTimeKind.Utc).AddTicks(1838),
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

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Tasks_TaskId",
                table: "AssignedTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
