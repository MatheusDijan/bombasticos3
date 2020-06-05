using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHS.Migrations
{
    public partial class EnumEmUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuario");
        }
    }
}
