using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciDogum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AilehID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                });

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
                    TurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    randevuAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuTur", x => x.TurID);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    SehirlerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.SehirlerID);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    IlcelerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SehirlerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.IlcelerID);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehirler_SehirlerID",
                        column: x => x.SehirlerID,
                        principalTable: "Sehirler",
                        principalColumn: "SehirlerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hastane",
                columns: table => new
                {
                    HastaneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlcelerID = table.Column<int>(type: "int", nullable: false),
                    SehirlerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastane", x => x.HastaneID);
                    table.ForeignKey(
                        name: "FK_Hastane_Ilce_IlcelerID",
                        column: x => x.IlcelerID,
                        principalTable: "Ilce",
                        principalColumn: "IlcelerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hastane_Sehirler_SehirlerID",
                        column: x => x.SehirlerID,
                        principalTable: "Sehirler",
                        principalColumn: "SehirlerID");
                });

            migrationBuilder.CreateTable(
                name: "Poliklinik",
                columns: table => new
                {
                    PolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinik", x => x.PolID);
                    table.ForeignKey(
                        name: "FK_Poliklinik_Hastane_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastane",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaneID = table.Column<int>(type: "int", nullable: false),
                    PolID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.DoktorID);
                    table.ForeignKey(
                        name: "FK_Doktor_Hastane_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hastane",
                        principalColumn: "HastaneID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doktor_Poliklinik_PolID",
                        column: x => x.PolID,
                        principalTable: "Poliklinik",
                        principalColumn: "PolID");
                });

            migrationBuilder.CreateTable(
                name: "DoktorKullanici",
                columns: table => new
                {
                    DoktorlarDoktorID = table.Column<int>(type: "int", nullable: false),
                    KullanicilarKullaniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorKullanici", x => new { x.DoktorlarDoktorID, x.KullanicilarKullaniciID });
                    table.ForeignKey(
                        name: "FK_DoktorKullanici_Doktor_DoktorlarDoktorID",
                        column: x => x.DoktorlarDoktorID,
                        principalTable: "Doktor",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorKullanici_Kullanici_KullanicilarKullaniciID",
                        column: x => x.KullanicilarKullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RandevuSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    TurID = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevu_Doktor_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktor",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_RandevuTur_TurID",
                        column: x => x.TurID,
                        principalTable: "RandevuTur",
                        principalColumn: "TurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_HastaneID",
                table: "Doktor",
                column: "HastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_PolID",
                table: "Doktor",
                column: "PolID");

            migrationBuilder.CreateIndex(
                name: "IX_DoktorKullanici_KullanicilarKullaniciID",
                table: "DoktorKullanici",
                column: "KullanicilarKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastane_IlcelerID",
                table: "Hastane",
                column: "IlcelerID");

            migrationBuilder.CreateIndex(
                name: "IX_Hastane_SehirlerID",
                table: "Hastane",
                column: "SehirlerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_SehirlerID",
                table: "Ilce",
                column: "SehirlerID");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinik_HastaneID",
                table: "Poliklinik",
                column: "HastaneID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_DoktorID",
                table: "Randevu",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciID",
                table: "Randevu",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_TurID",
                table: "Randevu",
                column: "TurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorKullanici");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Doktor");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "RandevuTur");

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
