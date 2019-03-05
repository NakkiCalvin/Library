using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_StorageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_StorageId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Authors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_StorageId",
                table: "Books",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_StorageId",
                table: "Authors",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
