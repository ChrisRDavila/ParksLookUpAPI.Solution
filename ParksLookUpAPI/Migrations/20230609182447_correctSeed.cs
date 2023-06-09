using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksLookUpAPI.Migrations
{
    public partial class correctSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4,
                columns: new[] { "Name", "State" },
                values: new object[] { "The Grand Tetons", "Wyoming" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4,
                columns: new[] { "Name", "State" },
                values: new object[] { "The Geand Tetons", "Wyonming" });
        }
    }
}
