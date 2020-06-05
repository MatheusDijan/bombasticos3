using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHS.Migrations
{
    public partial class CriacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_Dieta_DietaId",
                table: "Alimento");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DietaId",
                table: "Alimento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioId",
                table: "Usuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dieta_UsuarioId",
                table: "Dieta",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_Dieta_DietaId",
                table: "Alimento",
                column: "DietaId",
                principalTable: "Dieta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dieta_Usuario_UsuarioId",
                table: "Dieta",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_UsuarioId",
                table: "Usuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_Dieta_DietaId",
                table: "Alimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Dieta_Usuario_UsuarioId",
                table: "Dieta");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UsuarioId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Dieta_UsuarioId",
                table: "Dieta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "DietaId",
                table: "Alimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_Dieta_DietaId",
                table: "Alimento",
                column: "DietaId",
                principalTable: "Dieta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
