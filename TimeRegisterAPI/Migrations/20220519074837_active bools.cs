using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeRegisterAPI.Migrations
{
    public partial class activebools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostPerHour",
                table: "Projects",
                newName: "PricePerHour");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TimeReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "TimeReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TimeReports");

            migrationBuilder.DropColumn(
                name: "Processed",
                table: "TimeReports");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "PricePerHour",
                table: "Projects",
                newName: "CostPerHour");
        }
    }
}
