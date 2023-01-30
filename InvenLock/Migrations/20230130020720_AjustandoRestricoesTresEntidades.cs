using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoRestricoesTresEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<string>(type: "varchar(40)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7556)),
                    SituacaoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoEquip = table.Column<int>(type: "int", nullable: false),
                    DescEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    OcorrenciaId = table.Column<string>(type: "varchar(40)", nullable: false),
                    DescOcorrencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DataOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7092)),
                    DataFimOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.OcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "ConsertoEquip",
                columns: table => new
                {
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DescProblema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipamentoId = table.Column<string>(type: "varchar(40)", nullable: false),
                    OcorrenciaId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsertoEquip", x => x.ConsertoEquipId);
                    table.ForeignKey(
                        name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "OcorrenciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquip_EquipamentoId",
                table: "ConsertoEquip",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquip_OcorrenciaId",
                table: "ConsertoEquip",
                column: "OcorrenciaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsertoEquip");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Ocorrencias");
        }
    }
}
