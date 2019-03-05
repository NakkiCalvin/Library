using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ThreeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    StorageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Author_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_StorageId",
                table: "Books",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Author_StorageId",
                table: "Author",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Storage_StorageId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropIndex(
                name: "IX_Books_StorageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
