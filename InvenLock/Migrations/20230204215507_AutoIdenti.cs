using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class AutoIdenti : Migration
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
                    CodigoInterno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoEquip = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FuncionarioRecebedor = table.Column<string>(type: "varchar(70)", nullable: true),
                    MarcaEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NumOcorrencias = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                name: "ContatoFuncionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()"),
                    Celular = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    CelularCorp = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(70)", nullable: true),
                    EmailCorp = table.Column<string>(type: "VARCHAR(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoFuncionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_ContatoFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoFuncionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    FuncionarioCEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NomeRua = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    Complemento = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoFuncionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_EnderecoFuncionarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoEmprestimos",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    FuncionariosFuncionarioId = table.Column<string>(type: "varchar(70)", nullable: false),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: true),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoEmprestimos", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_EquipamentoEmprestimos_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId");
                    table.ForeignKey(
                        name: "FK_EquipamentoEmprestimos_Funcionarios_FuncionariosFuncionarioId",
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
                    CodigoInternoEquipamento = table.Column<int>(type: "int", nullable: false),
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
                name: "SucataEquips",
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
                    table.PrimaryKey("PK_SucataEquips", x => x.SucataEquipId);
                    table.ForeignKey(
                        name: "FK_SucataEquips_ConsertoEquips_ConsertoEquipId",
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
                name: "IX_EquipamentoEmprestimos_EquipamentoId",
                table: "EquipamentoEmprestimos",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoEmprestimos_FuncionariosFuncionarioId",
                table: "EquipamentoEmprestimos",
                column: "FuncionariosFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_FuncionarioId",
                table: "Ocorrencias",
                column: "FuncionarioId");

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
                name: "ContatoFuncionarios");

            migrationBuilder.DropTable(
                name: "EnderecoFuncionarios");

            migrationBuilder.DropTable(
                name: "EquipamentoEmprestimos");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "SucataEquips");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ConsertoEquips");

            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
