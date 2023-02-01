using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class TableOcorrenciaConsertoEquip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    OcorrenciaId = table.Column<string>(type: "varchar(70)", nullable: false),
                    DescOcorrencia = table.Column<string>(type: "varchar(300)", nullable: true),
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: true),
                    FuncionarioCPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    DataOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    DataFimOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.OcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "ConsertoEquips",
                columns: table => new
                {
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Procedimentos = table.Column<string>(type: "varchar(500)", nullable: true),
                    OcorrenciaId = table.Column<string>(type: "varchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsertoEquips", x => x.ConsertoEquipId);
                    table.ForeignKey(
                        name: "FK_ConsertoEquips_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "OcorrenciaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquips_OcorrenciaId",
                table: "ConsertoEquips",
                column: "OcorrenciaId",
                unique: true,
                filter: "[OcorrenciaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsertoEquips");

            migrationBuilder.DropTable(
                name: "Ocorrencias");
        }
    }
}
