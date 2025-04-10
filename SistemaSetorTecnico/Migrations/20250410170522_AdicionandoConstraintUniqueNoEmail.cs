using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoConstraintUniqueNoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Localidades_LocalidadesId",
                table: "Recoletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Motivos_MotivosId",
                table: "Recoletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Recoletas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MotivosId",
                table: "Recoletas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadesId",
                table: "Recoletas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Localidades_LocalidadesId",
                table: "Recoletas",
                column: "LocalidadesId",
                principalTable: "Localidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Motivos_MotivosId",
                table: "Recoletas",
                column: "MotivosId",
                principalTable: "Motivos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Recoletas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotivosId",
                table: "Recoletas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadesId",
                table: "Recoletas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recoletas_Status_StatusId",
                table: "Recoletas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
