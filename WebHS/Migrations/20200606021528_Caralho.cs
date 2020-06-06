using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHS.Migrations
{
    public partial class Caralho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietaId",
                table: "Dieta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dieta_DietaId",
                table: "Dieta",
                column: "DietaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dieta_Dieta_DietaId",
                table: "Dieta",
                column: "DietaId",
                principalTable: "Dieta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dieta_Dieta_DietaId",
                table: "Dieta");

            migrationBuilder.DropIndex(
                name: "IX_Dieta_DietaId",
                table: "Dieta");

            migrationBuilder.DropColumn(
                name: "DietaId",
                table: "Dieta");
        }
    }
}
