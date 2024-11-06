using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinverseSocialAPI.Migrations
{
    public partial class AddedLikesAndTypeLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cTypeLike",
                columns: table => new
                {
                    PkTypeLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cTypeLike", x => x.PkTypeLike);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    PkLike = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(type: "int", nullable: false),
                    FkPost = table.Column<int>(type: "int", nullable: false),
                    FkTypeLike = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.PkLike);
                    table.ForeignKey(
                        name: "FK_Likes_cTypeLike_FkTypeLike",
                        column: x => x.FkTypeLike,
                        principalTable: "cTypeLike",
                        principalColumn: "PkTypeLike",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_FkPost",
                        column: x => x.FkPost,
                        principalTable: "Posts",
                        principalColumn: "PkPost",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_sUser_FkUser",
                        column: x => x.FkUser,
                        principalTable: "sUser",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FkPost",
                table: "Likes",
                column: "FkPost");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FkTypeLike",
                table: "Likes",
                column: "FkTypeLike");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FkUser",
                table: "Likes",
                column: "FkUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "cTypeLike");
        }
    }
}
