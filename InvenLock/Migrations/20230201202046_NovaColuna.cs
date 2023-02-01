using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class NovaColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoInterno",
                table: "SucataEquip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoInterno",
                table: "Ocorrencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoInterno",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoInterno",
                table: "ConsertoEquips",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "SucataEquip");

            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "Ocorrencias");

            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "ConsertoEquips");
        }
    }
}
