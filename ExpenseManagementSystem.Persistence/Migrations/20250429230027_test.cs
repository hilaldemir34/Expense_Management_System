using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3507e505-5dc0-43c3-b114-bb301110e471",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELaKG4nDzhPqcRyw53nHgro9l+yd7zrmIyz0GO5NST2rn7LHCF6YrUqM+6ZTFqVuuQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1e8b1-3509-4632-952f-b083a54c080d",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOfsZaCFEfz1GTkpJCEb8WpJVlERlPjXbUEaHMq1YKM1ieNT+4cR4tnPY50jWUqFhg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3507e505-5dc0-43c3-b114-bb301110e471",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPvdrNBOtFsD+jm5WkHvYB/7MPKVS9j1GCyiVFUiUfDlfdt7M1Q/dAzN4p1yWOVK9Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1e8b1-3509-4632-952f-b083a54c080d",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM2p3126JCr4OrDMH8faDTtWtyUIF34zpgH1AdqmBXYey7l6+Yam2MgfrUtXxARXmw==");
        }
    }
}
