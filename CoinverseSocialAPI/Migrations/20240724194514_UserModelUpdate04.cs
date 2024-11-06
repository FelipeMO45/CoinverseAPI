using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinverseSocialAPI.Migrations
{
    public partial class UserModelUpdate04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isOnline",
                table: "sUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isOnline",
                table: "sUser");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "sUser");
        }
    }
}
