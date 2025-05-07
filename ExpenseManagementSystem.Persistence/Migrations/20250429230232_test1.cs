using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3507e505-5dc0-43c3-b114-bb301110e471",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM1tY12O7FCjh0v/JKC2TGl2I3cYp6hU02LVtZS0Oit6B9IKBDNGR1bjy83X7uIYhg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cca1e8b1-3509-4632-952f-b083a54c080d",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKW+srnwRLRCkT+zd+s5TZvmPoQiu6d+lNDHlXA4KEQHVgVWR+3gbTtsTDbZUEgJGA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
