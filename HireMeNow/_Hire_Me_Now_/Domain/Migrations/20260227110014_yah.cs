using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class yah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_CompanyUser_ProviderId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_ProviderId",
                table: "JobApplications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ProviderId",
                table: "JobApplications",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_CompanyUser_ProviderId",
                table: "JobApplications",
                column: "ProviderId",
                principalTable: "CompanyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
