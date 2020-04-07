using Microsoft.EntityFrameworkCore.Migrations;

namespace DubuisGelin.Data.Migrations
{
    public partial class intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeEnum",
                table: "Champs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeEnum",
                table: "Champs");
        }
    }
}
