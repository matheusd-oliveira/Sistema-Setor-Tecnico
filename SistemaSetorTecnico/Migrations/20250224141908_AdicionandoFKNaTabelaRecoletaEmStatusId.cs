using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFKNaTabelaRecoletaEmStatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recoletas_StatusId",
                table: "Recoletas",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas");

            migrationBuilder.DropIndex(
                name: "IX_Recoletas_StatusId",
                table: "Recoletas");
        }
    }
}
