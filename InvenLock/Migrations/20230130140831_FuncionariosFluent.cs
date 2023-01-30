using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class FuncionariosFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(40)", nullable: false),
                    NomeFuncionario = table.Column<string>(type: "varchar(60)", nullable: false),
                    SobreNomeFuncionario = table.Column<string>(type: "varchar(60)", nullable: false),
                    FuncionarioCPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataDemissao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    FuncionarioCargo = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    OcorrenciaId = table.Column<string>(type: "varchar(40)", nullable: false),
                    DescOcorrencia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FuncionarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DataOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataFimOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.OcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<string>(type: "varchar(40)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
                    SituacaoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoEquip = table.Column<int>(type: "int", nullable: false),
                    DescEquipamento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Funcionarios_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsertoEquip",
                columns: table => new
                {
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Procedimentos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EquipamentoId = table.Column<string>(type: "varchar(40)", nullable: true),
                    OcorrenciaId = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsertoEquip", x => x.ConsertoEquipId);
                    table.ForeignKey(
                        name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                    table.ForeignKey(
                        name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "OcorrenciaId");
                });

            migrationBuilder.CreateTable(
                name: "SucataEquips",
                columns: table => new
                {
                    SucataEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDescarte = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DescMotivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucataEquips", x => x.SucataEquipId);
                    table.ForeignKey(
                        name: "FK_SucataEquips_ConsertoEquip_ConsertoEquipId",
                        column: x => x.ConsertoEquipId,
                        principalTable: "ConsertoEquip",
                        principalColumn: "ConsertoEquipId",
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
                unique: true,
                filter: "[OcorrenciaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SucataEquips_ConsertoEquipId",
                table: "SucataEquips",
                column: "ConsertoEquipId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SucataEquips");

            migrationBuilder.DropTable(
                name: "ConsertoEquip");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
