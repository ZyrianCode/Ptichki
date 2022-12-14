using Microsoft.EntityFrameworkCore.Migrations;

namespace Ptichki.Data.Migrations
{
    public partial class ProcessTechnologyMakeNamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProcessTechnologies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProcessTechnologies");
        }
    }
}
