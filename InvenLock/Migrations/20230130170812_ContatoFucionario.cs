using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class ContatoFucionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EquipamentoId",
                table: "HistoricoEmpresEquips",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDevolucao",
                table: "HistoricoEmpresEquips",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "HistoricoEmpresEquips",
                type: "smalldatetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ContatoFuncionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(40)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(11)", nullable: true),
                    CelularCorp = table.Column<string>(type: "varchar(11)", nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    EmailCorp = table.Column<string>(type: "varchar(60)", nullable: true)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatoFuncionarios");

            migrationBuilder.AlterColumn<string>(
                name: "EquipamentoId",
                table: "HistoricoEmpresEquips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDevolucao",
                table: "HistoricoEmpresEquips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "HistoricoEmpresEquips",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
