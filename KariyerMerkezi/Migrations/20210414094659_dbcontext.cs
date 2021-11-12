using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerMerkezi.Migrations
{
    public partial class dbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Grup",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Grup",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
