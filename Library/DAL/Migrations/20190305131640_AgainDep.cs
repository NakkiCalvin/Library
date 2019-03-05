using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AgainDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Storage",
                newName: "StorageId");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "StorageId",
                table: "Storage",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Books",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StorageId",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Storage_StorageId",
                table: "Authors",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
