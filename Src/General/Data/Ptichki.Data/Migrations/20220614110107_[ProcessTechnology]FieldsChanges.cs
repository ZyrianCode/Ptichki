using Microsoft.EntityFrameworkCore.Migrations;

namespace Ptichki.Data.Migrations
{
    public partial class ProcessTechnologyFieldsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProcessTechnologies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProcessTechnologies");
        }
    }
}
