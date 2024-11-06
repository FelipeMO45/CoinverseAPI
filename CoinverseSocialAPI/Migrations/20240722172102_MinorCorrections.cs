using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinverseSocialAPI.Migrations
{
    public partial class MinorCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_sUser_FkUser",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_TypePosts_FkTypePost",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts");

            migrationBuilder.RenameTable(
                name: "TypePosts",
                newName: "cTypePost");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fullName",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkUser",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkUser",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cTypePost",
                table: "cTypePost",
                column: "PkTypePost");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_FkPost",
                table: "Comments",
                column: "FkPost",
                principalTable: "Posts",
                principalColumn: "PkPost");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_sUser_FkUser",
                table: "Comments",
                column: "FkUser",
                principalTable: "sUser",
                principalColumn: "PkUser",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_cTypePost_FkTypePost",
                table: "Posts",
                column: "FkTypePost",
                principalTable: "cTypePost",
                principalColumn: "PkTypePost",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_sUser_FkUser",
                table: "Posts",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_cTypePost_FkTypePost",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_sUser_FkUser",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cTypePost",
                table: "cTypePost");

            migrationBuilder.RenameTable(
                name: "cTypePost",
                newName: "TypePosts");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "fullName",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "sUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FkUser",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkUser",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePosts",
                table: "TypePosts",
                column: "PkTypePost");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_sUser_FkUser",
                table: "Posts",
                column: "FkUser",
                principalTable: "sUser",
                principalColumn: "PkUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_TypePosts_FkTypePost",
                table: "Posts",
                column: "FkTypePost",
                principalTable: "TypePosts",
                principalColumn: "PkTypePost",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
