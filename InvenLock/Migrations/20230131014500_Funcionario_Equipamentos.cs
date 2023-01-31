using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioEquipamentos : Migration
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
                    DataAdmissao = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DataDemissao = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FuncionarioCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<string>(type: "varchar(70)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_FuncionarioId",
                table: "Equipamentos",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
