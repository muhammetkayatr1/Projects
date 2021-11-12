using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerMerkezi.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    EtkinlikID = table.Column<int>(nullable: false),
                    Kapasite = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false),
                    Lokasyon = table.Column<string>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grup", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grup");
        }
    }
}
