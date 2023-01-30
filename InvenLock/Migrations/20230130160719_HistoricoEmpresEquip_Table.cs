using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoEmpresEquipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FuncionarioId",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoricoEmpresEquips",
                columns: table => new
                {
                    HistoricoEmpresEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipamentoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioId = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEmpresEquips", x => x.HistoricoEmpresEquipId);
                    table.ForeignKey(
                        name: "FK_HistoricoEmpresEquips_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEmpresEquips_FuncionarioId",
                table: "HistoricoEmpresEquips",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoEmpresEquips");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Equipamentos");
        }
    }
}
