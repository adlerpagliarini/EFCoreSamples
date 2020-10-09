using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSamples.Migrations
{
    public partial class ExtraMotivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraMotivation_ExtraFactor",
                table: "FullStackDeveloper",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraMotivation_ExtraFactor",
                table: "FullStackDeveloper");
        }
    }
}
