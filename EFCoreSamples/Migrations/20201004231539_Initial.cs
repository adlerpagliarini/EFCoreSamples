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
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    DevType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DatabaseStack = table.Column<bool>(nullable: true),
                    DatabasePreference = table.Column<string>(nullable: true),
                    MobileStack = table.Column<bool>(nullable: true),
                    MobileSystem = table.Column<string>(nullable: true),
                    CloudPreference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskToDo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DeveloperId = table.Column<string>(nullable: true)
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
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    TaskToDoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_TaskToDo_TaskToDoId",
                        column: x => x.TaskToDoId,
                        principalTable: "TaskToDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_TaskToDoId",
                table: "Skill",
                column: "TaskToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToDo_DeveloperId",
                table: "TaskToDo",
                column: "DeveloperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "TaskToDo");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
