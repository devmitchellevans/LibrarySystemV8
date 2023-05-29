using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystemV8.Migrations
{
    /// <inheritdoc />
    public partial class addisActiveauthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Authors",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Authors");
        }
    }
}
