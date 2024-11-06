using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinverseSocialAPI.Migrations
{
    public partial class InitialCoinverseDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sUser",
                columns: table => new
                {
                    PkUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sUser", x => x.PkUser);
                });

            migrationBuilder.CreateTable(
                name: "TypePosts",
                columns: table => new
                {
                    PkTypePost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePosts", x => x.PkTypePost);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PkPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkTypePost = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPostShared = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PkPost);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_IdPostShared",
                        column: x => x.IdPostShared,
                        principalTable: "Posts",
                        principalColumn: "PkPost",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_sUser_FkUser",
                        column: x => x.FkUser,
                        principalTable: "sUser",
                        principalColumn: "PkUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_TypePosts_FkTypePost",
                        column: x => x.FkTypePost,
                        principalTable: "TypePosts",
                        principalColumn: "PkTypePost",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FkTypePost",
                table: "Posts",
                column: "FkTypePost");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FkUser",
                table: "Posts",
                column: "FkUser");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdPostShared",
                table: "Posts",
                column: "IdPostShared");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "sUser");

            migrationBuilder.DropTable(
                name: "TypePosts");
        }
    }
}
