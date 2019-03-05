using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedModelAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                nullable: true);
        }
    }
}
