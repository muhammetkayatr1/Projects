using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerMerkezi.Migrations
{
    public partial class KM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Etkinlik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false),
                    Aciklama = table.Column<string>(nullable: true),
                    EtkinlikResim = table.Column<string>(nullable: true),
                    IsGroup = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    EgitimIcerigiHTML = table.Column<string>(nullable: true),
                    GrupAciklama = table.Column<string>(nullable: true),
                    Sira = table.Column<int>(nullable: false),
                    Tur = table.Column<int>(nullable: false),
                    Konferans_Kontenjan = table.Column<int>(nullable: true),
                    Basvuru_Acikmi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grup_Katilimci_Etkinlik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad_Soyad = table.Column<string>(nullable: true),
                    BolumAd = table.Column<string>(nullable: true),
                    FakulteAd = table.Column<string>(nullable: true),
                    Eposta = table.Column<string>(nullable: true),
                    GSM = table.Column<string>(nullable: true),
                    Sinif = table.Column<int>(nullable: false),
                    Durum = table.Column<string>(nullable: true),
                    Grup_Adi = table.Column<string>(nullable: true),
                    Grup_BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    Grup_BitisTarihi = table.Column<DateTime>(nullable: false),
                    Kapasite = table.Column<int>(nullable: false),
                    Egitim_Adi = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OgrenciNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grup_Katilimci_Etkinlik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(nullable: true),
                    EPosta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etkinlik");

            migrationBuilder.DropTable(
                name: "Grup_Katilimci_Etkinlik");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    durum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
