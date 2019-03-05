using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FinalThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Storage_StorageId",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Author_StorageId",
                table: "Authors",
                newName: "IX_Authors_StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_StorageId",
                table: "Author",
                newName: "IX_Author_StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Storage_StorageId",
                table: "Author",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
