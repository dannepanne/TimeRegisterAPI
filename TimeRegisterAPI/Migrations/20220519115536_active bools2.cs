using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeRegisterAPI.Migrations
{
    public partial class activebools2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TimeReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TimeReports");
        }
    }
}
