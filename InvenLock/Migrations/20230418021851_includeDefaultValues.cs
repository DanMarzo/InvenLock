using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class includeDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDescarte",
                table: "SucataEquips",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Ocorrencias",
                type: "datetime2(0)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimOcorrencia",
                table: "Ocorrencias",
                type: "datetime2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Demissao",
                table: "Funcionarios",
                type: "datetime2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Admissao",
                table: "Funcionarios",
                type: "datetime2(0)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Equipamentos",
                type: "datetime2(0)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "EquipamentoEmprestimos",
                type: "datetime2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDevolucao",
                table: "EquipamentoEmprestimos",
                type: "datetime2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "EnderecoFuncionarios",
                type: "datetime2(0)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "ContatoFuncionarios",
                type: "datetime2(0)",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Admissao", "CPF", "Demissao", "FuncionarioCargo", "Nome", "Sobrenome", "Status" },
                values: new object[] { 1, new DateTime(2023, 4, 17, 23, 18, 51, 592, DateTimeKind.Local).AddTicks(6550), "56053311839", null, 2, "Dan", "marzo", true });

            migrationBuilder.InsertData(
                table: "ContatoFuncionarios",
                columns: new[] { "FuncionarioId", "Celular", "CelularCorp", "Email", "EmailCorp", "UltimaAtualizacao" },
                values: new object[] { 1, null, null, "marzogildan@gmail.com", "marzogildan@rrsoft.com.br", new DateTime(2023, 4, 17, 23, 18, 51, 592, DateTimeKind.Local).AddTicks(1771) });

            migrationBuilder.CreateIndex(
                name: "IX_ContatoFuncionarios_Email",
                table: "ContatoFuncionarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContatoFuncionarios_Email",
                table: "ContatoFuncionarios");

            migrationBuilder.DeleteData(
                table: "ContatoFuncionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDescarte",
                table: "SucataEquips",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Ocorrencias",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimOcorrencia",
                table: "Ocorrencias",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Demissao",
                table: "Funcionarios",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Admissao",
                table: "Funcionarios",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Equipamentos",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "EquipamentoEmprestimos",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDevolucao",
                table: "EquipamentoEmprestimos",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "EnderecoFuncionarios",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "ContatoFuncionarios",
                type: "DATETIME",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
