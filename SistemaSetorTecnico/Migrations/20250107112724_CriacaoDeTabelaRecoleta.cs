using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeTabelaRecoleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recoletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TecnicoResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRecoleta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalRecoleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroOS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoRecoleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaboratorioApoio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BioquimicoResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataContato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ColetaConcluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recoletas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recoletas");
        }
    }
}
