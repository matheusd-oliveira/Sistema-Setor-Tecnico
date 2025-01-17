using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaNaTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBioquimico",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBioquimico",
                table: "Usuarios");
        }
    }
}
