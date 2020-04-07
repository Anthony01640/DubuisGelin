using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DubuisGelin.Data.Migrations
{
    public partial class AddliaisonValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLiaison",
                table: "Value",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LiaisonValueChamps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonValueChamps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Value_IdLiaison",
                table: "Value",
                column: "IdLiaison");

            migrationBuilder.AddForeignKey(
                name: "FK_Value_LiaisonValueChamps_IdLiaison",
                table: "Value",
                column: "IdLiaison",
                principalTable: "LiaisonValueChamps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Value_LiaisonValueChamps_IdLiaison",
                table: "Value");

            migrationBuilder.DropTable(
                name: "LiaisonValueChamps");

            migrationBuilder.DropIndex(
                name: "IX_Value_IdLiaison",
                table: "Value");

            migrationBuilder.DropColumn(
                name: "IdLiaison",
                table: "Value");
        }
    }
}
