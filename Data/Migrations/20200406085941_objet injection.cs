using Microsoft.EntityFrameworkCore.Migrations;

namespace DubuisGelin.Data.Migrations
{
    public partial class objetinjection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "b1ad5b97-999b-48c1-bb2c-c971792aaa6b", "Utilisateur", "UTILISATEUR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1", "b1ad5b97-999b-48c1-bb2c-c971792aaa6b" });
        }
    }
}
