using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Equipamentos",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EnderecoFuncionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<string>(type: "varchar(40)", nullable: false),
                    FuncionarioCEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NomeRua = table.Column<string>(type: "varchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValueSql: "GETDATE()")
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoFuncionarios");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);
        }
    }
}
