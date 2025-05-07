using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntityBaseAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "Expenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Expenses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ExpenseRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "ExpenseRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "ExpenseRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ExpenseDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "ExpenseDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExpenseDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "ExpenseDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ExpenseCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "ExpenseCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "ExpenseCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c86e33-bd4c-4555-983f-84bcc70dea79",
                columns: new[] { "CreatedAtUtc", "DeletedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438c4a75-f32b-43b6-8b17-b54348c1fe3a",
                columns: new[] { "CreatedAtUtc", "DeletedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3507e505-5dc0-43c3-b114-bb301110e471",
                columns: new[] { "CreatedAtUtc", "DeletedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1e8b1-3509-4632-952f-b083a54c080d",
                columns: new[] { "CreatedAtUtc", "DeletedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "AspNetRoles");
        }
    }
}
