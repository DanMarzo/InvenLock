using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenLock.Migrations
{
    /// <inheritdoc />
    public partial class SucataEquipAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                table: "ConsertoEquip");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                table: "ConsertoEquip");

            migrationBuilder.DropIndex(
                name: "IX_ConsertoEquip_OcorrenciaId",
                table: "ConsertoEquip");

            migrationBuilder.DropColumn(
                name: "DescProblema",
                table: "ConsertoEquip");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DescOcorrencia",
                table: "Ocorrencias",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Ocorrencias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7898),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.AlterColumn<string>(
                name: "DescEquipamento",
                table: "Equipamentos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Equipamentos",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7513),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.AlterColumn<string>(
                name: "OcorrenciaId",
                table: "ConsertoEquip",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "EquipamentoId",
                table: "ConsertoEquip",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AddColumn<string>(
                name: "Procedimentos",
                table: "ConsertoEquip",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SucataEquips",
                columns: table => new
                {
                    SucataEquipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDescarte = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(8131)),
                    DescMotivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConsertoEquipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucataEquips", x => x.SucataEquipId);
                    table.ForeignKey(
                        name: "FK_SucataEquips_ConsertoEquip_ConsertoEquipId",
                        column: x => x.ConsertoEquipId,
                        principalTable: "ConsertoEquip",
                        principalColumn: "ConsertoEquipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquip_OcorrenciaId",
                table: "ConsertoEquip",
                column: "OcorrenciaId",
                unique: true,
                filter: "[OcorrenciaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SucataEquips_ConsertoEquipId",
                table: "SucataEquips",
                column: "ConsertoEquipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                table: "ConsertoEquip",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "EquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                table: "ConsertoEquip",
                column: "OcorrenciaId",
                principalTable: "Ocorrencias",
                principalColumn: "OcorrenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                table: "ConsertoEquip");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                table: "ConsertoEquip");

            migrationBuilder.DropTable(
                name: "SucataEquips");

            migrationBuilder.DropIndex(
                name: "IX_ConsertoEquip_OcorrenciaId",
                table: "ConsertoEquip");

            migrationBuilder.DropColumn(
                name: "Procedimentos",
                table: "ConsertoEquip");

            migrationBuilder.AlterColumn<string>(
                name: "FuncionarioId",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescOcorrencia",
                table: "Ocorrencias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Ocorrencias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7092),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.AlterColumn<string>(
                name: "DescEquipamento",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrega",
                table: "Equipamentos",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 29, 23, 7, 20, 792, DateTimeKind.Local).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.AlterColumn<string>(
                name: "OcorrenciaId",
                table: "ConsertoEquip",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EquipamentoId",
                table: "ConsertoEquip",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescProblema",
                table: "ConsertoEquip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ConsertoEquip_OcorrenciaId",
                table: "ConsertoEquip",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsertoEquip_Equipamentos_EquipamentoId",
                table: "ConsertoEquip",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "EquipamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsertoEquip_Ocorrencias_OcorrenciaId",
                table: "ConsertoEquip",
                column: "OcorrenciaId",
                principalTable: "Ocorrencias",
                principalColumn: "OcorrenciaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
