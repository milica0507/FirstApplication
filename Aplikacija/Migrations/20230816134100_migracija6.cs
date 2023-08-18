using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija.Migrations
{
    public partial class migracija6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authors_Book_Authors_Book_AuthorId",
                table: "Book_Authors");

            migrationBuilder.DropIndex(
                name: "IX_Book_Authors_Book_AuthorId",
                table: "Book_Authors");

            migrationBuilder.DropColumn(
                name: "Book_AuthorId",
                table: "Book_Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_AuthorId",
                table: "Book_Authors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_Book_AuthorId",
                table: "Book_Authors",
                column: "Book_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authors_Book_Authors_Book_AuthorId",
                table: "Book_Authors",
                column: "Book_AuthorId",
                principalTable: "Book_Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
