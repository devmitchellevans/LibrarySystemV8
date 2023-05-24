using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystemV8.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookCategoryIdFieldSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategories_BookCategoryFkId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCategoryFkId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCategoryFkId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BoookCategoryId",
                table: "Books",
                newName: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategories_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "BookCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCategories_BookCategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books");
             
            migrationBuilder.RenameColumn(
                name: "BookCategoryId",
                table: "Books",
                newName: "BoookCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BookCategoryFkId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryFkId",
                table: "Books",
                column: "BookCategoryFkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCategories_BookCategoryFkId",
                table: "Books",
                column: "BookCategoryFkId",
                principalTable: "BookCategories",
                principalColumn: "Id");
        }
    }
}
