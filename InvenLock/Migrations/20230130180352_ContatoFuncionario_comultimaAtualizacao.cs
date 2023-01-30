using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class ContatoFuncionariocomultimaAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "ContatoFuncionarios",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUltimaAtualizacao",
                table: "ContatoFuncionarios");
        }
    }
}
