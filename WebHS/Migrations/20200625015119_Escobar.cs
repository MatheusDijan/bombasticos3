using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHS.Migrations
{
    public partial class Escobar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreinoId",
                table: "Treino",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreinoId",
                table: "Atividade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Treino_TreinoId",
                table: "Treino",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_TreinoId",
                table: "Atividade",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Treino_TreinoId",
                table: "Atividade",
                column: "TreinoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Treino_TreinoId",
                table: "Treino",
                column: "TreinoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Treino_TreinoId",
                table: "Atividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Treino_TreinoId",
                table: "Treino");

            migrationBuilder.DropIndex(
                name: "IX_Treino_TreinoId",
                table: "Treino");

            migrationBuilder.DropIndex(
                name: "IX_Atividade_TreinoId",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "TreinoId",
                table: "Treino");

            migrationBuilder.DropColumn(
                name: "TreinoId",
                table: "Atividade");
        }
    }
}
