using Microsoft.EntityFrameworkCore.Migrations;

namespace Visitor_Management_System.Data.Migrations
{
    public partial class UpdatePark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Locartion",
                table: "Parks",
                newName: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Parks",
                newName: "Locartion");
        }
    }
}
