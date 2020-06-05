using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHS.Migrations
{
    public partial class PrimeiroBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Repeticoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dieta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dias = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dieta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dias = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CREF = table.Column<string>(nullable: true),
                    CRN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Calorias = table.Column<string>(nullable: true),
                    UnidadeMedida = table.Column<string>(nullable: true),
                    Macronutrientes = table.Column<string>(nullable: true),
                    Micronutrientes = table.Column<string>(nullable: true),
                    DietaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimento_Dieta_DietaId",
                        column: x => x.DietaId,
                        principalTable: "Dieta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_DietaId",
                table: "Alimento",
                column: "DietaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Treino");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Dieta");
        }
    }
}
