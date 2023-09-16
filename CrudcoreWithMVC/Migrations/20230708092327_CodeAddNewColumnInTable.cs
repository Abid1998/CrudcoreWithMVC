using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudcoreWithMVC.Migrations
{
    public partial class CodeAddNewColumnInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Standard",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Standard",
                table: "Students");
        }
    }
}
