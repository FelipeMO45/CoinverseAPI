using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinverseSocialAPI.Migrations
{
    public partial class CommentsAndFollowers02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments",
                column: "FkPost",
                principalTable: "Posts",
                principalColumn: "PkPost",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments",
                column: "FkUser",
                principalTable: "sUser",
                principalColumn: "PkUser",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments",
                column: "FkPost",
                principalTable: "Posts",
                principalColumn: "PkPost",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments",
                column: "FkUser",
                principalTable: "sUser",
                principalColumn: "PkUser",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
