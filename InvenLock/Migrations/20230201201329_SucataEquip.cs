using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class SucataEquip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MotivoSucata",
                table: "Ocorrencias",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SucataEquip",
                columns: table => new
                {
                    SucataEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDescarte = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    MotivoSucata = table.Column<string>(type: "varchar(250)", nullable: true),
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
                name: "IX_SucataEquip_ConsertoEquipId",
                table: "SucataEquip",
                column: "ConsertoEquipId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SucataEquip");

            migrationBuilder.DropColumn(
                name: "MotivoSucata",
                table: "Ocorrencias");
        }
    }
}
