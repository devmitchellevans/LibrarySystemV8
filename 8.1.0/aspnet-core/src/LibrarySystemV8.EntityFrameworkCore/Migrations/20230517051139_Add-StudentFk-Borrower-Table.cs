using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystemV8.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentFkBorrowerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Borrowers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_StudentId",
                table: "Borrowers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowers_Students_StudentId",
                table: "Borrowers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowers_Students_StudentId",
                table: "Borrowers");

            migrationBuilder.DropIndex(
                name: "IX_Borrowers_StudentId",
                table: "Borrowers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Borrowers");
        }
    }
}
