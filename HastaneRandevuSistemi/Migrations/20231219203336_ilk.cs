using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPasword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "RandevuTur",
                columns: table => new
                {
                    randevuTUR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    randevuAD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuTur", x => x.randevuTUR);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    sehirID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sehirAD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.sehirID);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    ilceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sehirID = table.Column<int>(type: "int", nullable: false),
                    ilceAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sehirlersehirID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.ilceID);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehirler_sehirlersehirID",
                        column: x => x.sehirlersehirID,
                        principalTable: "Sehirler",
                        principalColumn: "sehirID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hastane",
                columns: table => new
                {
                    hastaneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sehirID = table.Column<int>(type: "int", nullable: false),
                    ilceID = table.Column<int>(type: "int", nullable: false),
                    hastaneAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlcelerilceID = table.Column<int>(type: "int", nullable: false),
                    SehirlersehirID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastane", x => x.hastaneID);
                    table.ForeignKey(
                        name: "FK_Hastane_Ilce_IlcelerilceID",
                        column: x => x.IlcelerilceID,
                        principalTable: "Ilce",
                        principalColumn: "ilceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hastane_Sehirler_SehirlersehirID",
                        column: x => x.SehirlersehirID,
                        principalTable: "Sehirler",
                        principalColumn: "sehirID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinik",
                columns: table => new
                {
                    polID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    polAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hastaneID = table.Column<int>(type: "int", nullable: true),
                    hastanelerhastaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinik", x => x.polID);
                    table.ForeignKey(
                        name: "FK_Poliklinik_Hastane_hastanelerhastaneID",
                        column: x => x.hastanelerhastaneID,
                        principalTable: "Hastane",
                        principalColumn: "hastaneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    doktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doktorAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hastaneID = table.Column<int>(type: "int", nullable: false),
                    polID = table.Column<int>(type: "int", nullable: false),
                    hastanelerhastaneID = table.Column<int>(type: "int", nullable: false),
                    polikliniklerpolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.doktorID);
                    table.ForeignKey(
                        name: "FK_Doktor_Hastane_hastanelerhastaneID",
                        column: x => x.hastanelerhastaneID,
                        principalTable: "Hastane",
                        principalColumn: "hastaneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doktor_Poliklinik_polikliniklerpolID",
                        column: x => x.polikliniklerpolID,
                        principalTable: "Poliklinik",
                        principalColumn: "polID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    kullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullaniciAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullaniciSOYAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullaniciDOGUM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kullaniciSIFRE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ailehID = table.Column<int>(type: "int", nullable: false),
                    doktorlardoktorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.kullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanici_Doktor_doktorlardoktorID",
                        column: x => x.doktorlardoktorID,
                        principalTable: "Doktor",
                        principalColumn: "doktorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    randevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciID = table.Column<int>(type: "int", nullable: false),
                    doktorID = table.Column<int>(type: "int", nullable: false),
                    randevuTARIH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    randevuSAAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    randevuTUR = table.Column<int>(type: "int", nullable: true),
                    turrandevuTUR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.randevuID);
                    table.ForeignKey(
                        name: "FK_Randevu_Doktor_doktorID",
                        column: x => x.doktorID,
                        principalTable: "Doktor",
                        principalColumn: "doktorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevu_Kullanici_kullaniciID",
                        column: x => x.kullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "kullaniciID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevu_RandevuTur_turrandevuTUR",
                        column: x => x.turrandevuTUR,
                        principalTable: "RandevuTur",
                        principalColumn: "randevuTUR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_hastanelerhastaneID",
                table: "Doktor",
                column: "hastanelerhastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_polikliniklerpolID",
                table: "Doktor",
                column: "polikliniklerpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastane_IlcelerilceID",
                table: "Hastane",
                column: "IlcelerilceID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastane_SehirlersehirID",
                table: "Hastane",
                column: "SehirlersehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_sehirlersehirID",
                table: "Ilce",
                column: "sehirlersehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_doktorlardoktorID",
                table: "Kullanici",
                column: "doktorlardoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinik_hastanelerhastaneID",
                table: "Poliklinik",
                column: "hastanelerhastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_doktorID",
                table: "Randevu",
                column: "doktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_kullaniciID",
                table: "Randevu",
                column: "kullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_turrandevuTUR",
                table: "Randevu",
                column: "turrandevuTUR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "RandevuTur");

            migrationBuilder.DropTable(
                name: "Doktor");

            migrationBuilder.DropTable(
                name: "Poliklinik");

            migrationBuilder.DropTable(
                name: "Hastane");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Sehirler");
        }
    }
}
