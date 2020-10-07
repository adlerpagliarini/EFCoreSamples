using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSamples.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    DevType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BackEndDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatabaseStack = table.Column<bool>(type: "bit", nullable: false),
                    DatabasePreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackEndDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackEndDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrontEndDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileStack = table.Column<bool>(type: "bit", nullable: false),
                    MobileSystem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontEndDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrontEndDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FullStackDeveloper",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CloudPreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullStackDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullStackDeveloper_Developer_Id",
                        column: x => x.Id,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DeveloperId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskToDo_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillTaskToDo",
                columns: table => new
                {
                    SkillsId = table.Column<long>(type: "bigint", nullable: false),
                    TasksToDoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTaskToDo", x => new { x.SkillsId, x.TasksToDoId });
                    table.ForeignKey(
                        name: "FK_SkillTaskToDo_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTaskToDo_TaskToDo_TasksToDoId",
                        column: x => x.TasksToDoId,
                        principalTable: "TaskToDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillTaskToDo_TasksToDoId",
                table: "SkillTaskToDo",
                column: "TasksToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_DeveloperId",
                table: "TaskToDo",
                column: "DeveloperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackEndDeveloper");

            migrationBuilder.DropTable(
                name: "FrontEndDeveloper");

            migrationBuilder.DropTable(
                name: "FullStackDeveloper");

            migrationBuilder.DropTable(
                name: "SkillTaskToDo");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "TaskToDo");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
