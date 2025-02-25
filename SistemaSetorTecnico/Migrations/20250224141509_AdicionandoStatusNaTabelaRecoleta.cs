using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoStatusNaTabelaRecoleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Recoletas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Recoletas");
        }
    }
}
