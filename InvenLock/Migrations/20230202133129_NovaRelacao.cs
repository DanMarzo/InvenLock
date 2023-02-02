using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class NovaRelacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false),
                    SituacaoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FuncionarioRecebedor = table.Column<string>(type: "varchar(70)", nullable: true),
                    MarcaEquipamento = table.Column<string>(type: "varchar(20)", nullable: true),
                    DescEquipamento = table.Column<string>(type: "varchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

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
                name: "ConsertoEquips",
                columns: table => new
                {
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Procedimentos = table.Column<string>(type: "varchar(500)", nullable: true),
                    CodigoInterno = table.Column<string>(type: "varchar(70)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoEmprestimo",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    FuncionariosFuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: true),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoEmprestimo", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_EquipamentoEmprestimo_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                    table.ForeignKey(
                        name: "FK_EquipamentoEmprestimo_Funcionarios_FuncionariosFuncionarioId",
                        column: x => x.FuncionariosFuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    OcorrenciaId = table.Column<string>(type: "varchar(70)", nullable: false),
                    DescOcorrencia = table.Column<string>(type: "varchar(300)", nullable: true),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: true),
                    FuncionarioCPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    SituacaoConserto = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    MotivoSucata = table.Column<string>(type: "varchar(200)", nullable: true),
                    DataOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    DataFimOcorrencia = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.OcorrenciaId);
                    table.ForeignKey(
                        name: "FK_Ocorrencias_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "SucataEquip",
                columns: table => new
                {
                    SucataEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDescarte = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    MotivoSucata = table.Column<string>(type: "varchar(250)", nullable: true),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false),
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucataEquip", x => x.SucataEquipId);
                    table.ForeignKey(
                        name: "FK_SucataEquip_ConsertoEquips_ConsertoEquipId",
                        column: x => x.ConsertoEquipId,
                        principalTable: "ConsertoEquips",
                        principalColumn: "ConsertoEquipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquips_EquipamentoId",
                table: "ConsertoEquips",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoEmprestimo_EquipamentoId",
                table: "EquipamentoEmprestimo",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoEmprestimo_FuncionariosFuncionarioId",
                table: "EquipamentoEmprestimo",
                column: "FuncionariosFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_FuncionarioId",
                table: "Ocorrencias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SucataEquip_ConsertoEquipId",
                table: "SucataEquip",
                column: "ConsertoEquipId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoEmprestimo");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "SucataEquip");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ConsertoEquips");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
