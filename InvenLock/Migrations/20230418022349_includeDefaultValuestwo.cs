using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class includeDefaultValuestwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Pwdhash",
                table: "Funcionarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Pwdsalt",
                table: "Funcionarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ContatoFuncionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1,
                column: "UltimaAtualizacao",
                value: new DateTime(2023, 4, 17, 23, 23, 49, 538, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1,
                columns: new[] { "Admissao", "Pwdhash", "Pwdsalt" },
                values: new object[] { new DateTime(2023, 4, 17, 23, 23, 49, 539, DateTimeKind.Local).AddTicks(1871), new byte[] { 180, 14, 98, 247, 116, 23, 208, 85, 255, 49, 35, 69, 173, 47, 35, 86, 133, 190, 49, 218, 238, 87, 199, 102, 59, 203, 124, 216, 245, 245, 141, 108, 191, 17, 44, 94, 97, 20, 5, 164, 159, 53, 165, 94, 134, 133, 6, 35, 174, 248, 66, 77, 147, 234, 176, 190, 146, 210, 208, 83, 38, 20, 136, 96, 163, 181, 148, 245, 40, 18, 197, 18, 170, 157, 19, 215, 160, 207, 250, 101, 41, 88, 32, 26, 212, 86, 162, 32, 46, 167, 75, 206, 37, 41, 81, 209, 231, 192, 105, 7, 113, 59, 35, 23, 253, 215, 242, 30, 61, 83, 24, 188, 174, 70, 3, 115, 84, 8, 36, 241, 228, 54, 67, 174, 54, 182, 139, 8 }, new byte[] { 4, 89, 133, 170, 78, 123, 28, 16, 11, 179, 15, 185, 57, 99, 254, 12, 138, 229, 39, 45, 91, 1, 213, 100, 61, 163, 160, 86, 104, 226, 51, 62, 222, 204, 85, 150, 76, 251, 138, 226, 135, 166, 44, 212, 134, 52, 91, 26, 244, 111, 127, 95, 5, 242, 67, 65, 167, 34, 219, 228, 30, 203, 89, 94 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pwdhash",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Pwdsalt",
                table: "Funcionarios");

            migrationBuilder.UpdateData(
                table: "ContatoFuncionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1,
                column: "UltimaAtualizacao",
                value: new DateTime(2023, 4, 17, 23, 18, 51, 592, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "FuncionarioId",
                keyValue: 1,
                column: "Admissao",
                value: new DateTime(2023, 4, 17, 23, 18, 51, 592, DateTimeKind.Local).AddTicks(6550));
        }
    }
}
