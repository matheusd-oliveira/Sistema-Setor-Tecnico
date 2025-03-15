using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFKsDeLocalidadeEMotivoEmRecoleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.DropColumn(
                name: "LocalRecoleta",
                table: "Recoletas");

            migrationBuilder.DropColumn(
                name: "MotivoRecoleta",
                table: "Recoletas");

            migrationBuilder.AddColumn<string>(
              name: "LocalidadesId",
              table: "Recoletas",
              type: "int",
              nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivosId",
                table: "Recoletas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recoletas_LocalidadesId",
                table: "Recoletas",
                column: "LocalidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Recoletas_MotivosId",
                table: "Recoletas",
                column: "MotivosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Localidades_LocalidadesId",
                table: "Recoletas",
                column: "LocalidadesId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Motivos_MotivosId",
                table: "Recoletas",
                column: "MotivosId",
                principalTable: "Motivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Localidades_LocalidadesId",
                table: "Recoletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Motivos_MotivosId",
                table: "Recoletas");

            migrationBuilder.DropIndex(
                name: "IX_Recoletas_LocalidadesId",
                table: "Recoletas");

            migrationBuilder.DropIndex(
                name: "IX_Recoletas_MotivosId",
                table: "Recoletas");

            migrationBuilder.AddColumn<string>(
                name: "LocalRecoleta",
                table: "Recoletas",
                type: "string",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoRecoleta",
                table: "Recoletas",
                type: "string",
                nullable: true);
        }
    }
}
