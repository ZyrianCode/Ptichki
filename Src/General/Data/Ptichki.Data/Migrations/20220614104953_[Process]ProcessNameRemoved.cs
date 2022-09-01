using Microsoft.EntityFrameworkCore.Migrations;

namespace Ptichki.Data.Migrations
{
    public partial class ProcessProcessNameRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "Processes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
