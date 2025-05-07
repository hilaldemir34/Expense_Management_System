using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExpeseCategoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseCategories");
        }
    }
}
