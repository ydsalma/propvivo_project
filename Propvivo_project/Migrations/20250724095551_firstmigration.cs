using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Propvivo_project.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    workDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    totalWorkMinutes = table.Column<int>(type: "int", nullable: true),
                    totalBreakMinutes = table.Column<int>(type: "int", nullable: true),
                    completed8Hours = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estimatedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    isSelfAssigned = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: true),
                    assignedTo = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedUserUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_TaskAssignments_Tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                    table.ForeignKey(
                        name: "FK_TaskAssignments_Users_AssignedUserUserId",
                        column: x => x.AssignedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    QueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.QueryId);
                    table.ForeignKey(
                        name: "FK_Queries_TaskAssignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "TaskAssignments",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK_Queries_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TaskLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentId = table.Column<int>(type: "int", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isBreak = table.Column<bool>(type: "bit", nullable: true),
                    durationMinutes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_TaskLogs_TaskAssignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "TaskAssignments",
                        principalColumn: "AssignmentId");
                });

            migrationBuilder.CreateTable(
                name: "QueryResponses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queryId = table.Column<int>(type: "int", nullable: true),
                    responderId = table.Column<int>(type: "int", nullable: true),
                    responseText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryResponses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_QueryResponses_Queries_queryId",
                        column: x => x.queryId,
                        principalTable: "Queries",
                        principalColumn: "QueryId");
                    table.ForeignKey(
                        name: "FK_QueryResponses_Users_responderId",
                        column: x => x.responderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_userId",
                table: "Attendances",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_assignmentId",
                table: "Queries",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_userId",
                table: "Queries",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryResponses_queryId",
                table: "QueryResponses",
                column: "queryId");

            migrationBuilder.CreateIndex(
                name: "IX_QueryResponses_responderId",
                table: "QueryResponses",
                column: "responderId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignments_AssignedUserUserId",
                table: "TaskAssignments",
                column: "AssignedUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignments_taskId",
                table: "TaskAssignments",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLogs_assignmentId",
                table: "TaskLogs",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorUserId",
                table: "Tasks",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "QueryResponses");

            migrationBuilder.DropTable(
                name: "TaskLogs");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "TaskAssignments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
