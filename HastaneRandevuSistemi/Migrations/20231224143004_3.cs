using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktor_Poli_PolID",
                table: "Doktor");

            migrationBuilder.DropForeignKey(
                name: "FK_Poli_Hastane_HastaneID",
                table: "Poli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poli",
                table: "Poli");

            migrationBuilder.RenameTable(
                name: "Poli",
                newName: "Poliklinik");

            migrationBuilder.RenameIndex(
                name: "IX_Poli_HastaneID",
                table: "Poliklinik",
                newName: "IX_Poliklinik_HastaneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poliklinik",
                table: "Poliklinik",
                column: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktor_Poliklinik_PolID",
                table: "Doktor",
                column: "PolID",
                principalTable: "Poliklinik",
                principalColumn: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Poliklinik_Hastane_HastaneID",
                table: "Poliklinik",
                column: "HastaneID",
                principalTable: "Hastane",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktor_Poliklinik_PolID",
                table: "Doktor");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliklinik_Hastane_HastaneID",
                table: "Poliklinik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poliklinik",
                table: "Poliklinik");

            migrationBuilder.RenameTable(
                name: "Poliklinik",
                newName: "Poli");

            migrationBuilder.RenameIndex(
                name: "IX_Poliklinik_HastaneID",
                table: "Poli",
                newName: "IX_Poli_HastaneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poli",
                table: "Poli",
                column: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktor_Poli_PolID",
                table: "Doktor",
                column: "PolID",
                principalTable: "Poli",
                principalColumn: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Poli_Hastane_HastaneID",
                table: "Poli",
                column: "HastaneID",
                principalTable: "Hastane",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
