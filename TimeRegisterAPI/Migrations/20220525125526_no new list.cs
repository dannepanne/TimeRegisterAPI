using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeRegisterAPI.Migrations
{
    public partial class nonewlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReports_Projects_ProjectId",
                table: "TimeReports",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeReports_Projects_ProjectId",
                table: "TimeReports");

            migrationBuilder.DropIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");
        }
    }
}
