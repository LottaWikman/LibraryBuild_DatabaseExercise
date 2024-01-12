using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBooksAuthorsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorID",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Author_Book_BookID",
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

            migrationBuilder.DropIndex(
                name: "IX_Author_BookID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Author");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthorID = table.Column<int>(type: "int", nullable: false),
                    BooksBookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorID, x.BooksBookID });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsAuthorID",
                        column: x => x.AuthorsAuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookID",
                table: "AuthorBook",
                column: "BooksBookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

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

            migrationBuilder.AddColumn<int>(
                name: "BookID",
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

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookID",
                table: "Author",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_BookAuthor_BookAuthorID",
                table: "Author",
                column: "BookAuthorID",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Book_BookID",
                table: "Author",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookAuthor_BookAuthorID",
                table: "Book",
                column: "BookAuthorID",
                principalTable: "BookAuthor",
                principalColumn: "BookAuthorID");
        }
    }
}
