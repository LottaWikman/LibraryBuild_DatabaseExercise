using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2.Migrations
{
    /// <inheritdoc />
    public partial class FixCreatedJointTableBookAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookAuthorID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorID",
                table: "Author",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookAuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.BookAuthorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookAuthorID",
                table: "Book",
                column: "BookAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookAuthorID",
                table: "Author",
                column: "BookAuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorID",
                table: "Author",
                column: "BookAuthorID",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookAuthor_BookAuthorID",
                table: "Book",
                column: "BookAuthorID",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorID",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookAuthor_BookAuthorID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookAuthorID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Author_BookAuthorID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Author");
        }
    }
}
