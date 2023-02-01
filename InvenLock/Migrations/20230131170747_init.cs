using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    NomeFuncionario = table.Column<string>(type: "varchar(40)", nullable: false),
                    SobreNomeFuncionario = table.Column<string>(type: "varchar(50)", nullable: false),
                    FuncionarioCPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    DataDemissao = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FuncionarioCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

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
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    SituacaoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FuncionarioRecebedor = table.Column<string>(type: "varchar(70)", nullable: true),
                    MarcaEquipamento = table.Column<string>(type: "varchar(20)", nullable: true),
                    DescEquipamento = table.Column<string>(type: "varchar(70)", nullable: true),
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "ConsertoEquips",
                columns: table => new
                {
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Procedimentos = table.Column<string>(type: "varchar(500)", nullable: true),
                    OcorrenciaId = table.Column<string>(type: "varchar(70)", nullable: true),
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsertoEquips", x => x.ConsertoEquipId);
                    table.ForeignKey(
                        name: "FK_ConsertoEquips_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                    table.ForeignKey(
                        name: "FK_ConsertoEquips_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "OcorrenciaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquips_EquipamentoId",
                table: "ConsertoEquips",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquips_OcorrenciaId",
                table: "ConsertoEquips",
                column: "OcorrenciaId",
                unique: true,
                filter: "[OcorrenciaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_FuncionarioId",
                table: "Equipamentos",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsertoEquips");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
