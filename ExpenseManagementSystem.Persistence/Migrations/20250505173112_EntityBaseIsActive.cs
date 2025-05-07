using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntityBaseIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
