using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystemV8.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentIdBookCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Departments_DepartmentFkId",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_DepartmentFkId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "DepartmentFkId",
                table: "BookCategories");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_DepartmentId",
                table: "BookCategories",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Departments_DepartmentId",
                table: "BookCategories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Departments_DepartmentId",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_DepartmentId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "BookCategories");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentFkId",
                table: "BookCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_DepartmentFkId",
                table: "BookCategories",
                column: "DepartmentFkId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Departments_DepartmentFkId",
                table: "BookCategories",
                column: "DepartmentFkId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
