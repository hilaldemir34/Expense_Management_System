using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseDocumentCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDocuments_ExpenseRequests_ExpenseRequestId",
                        column: x => x.ExpenseRequestId,
                        principalTable: "ExpenseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_ExpenseRequestId",
                table: "ExpenseDocuments",
                column: "ExpenseRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDocuments");
        }
    }
}
