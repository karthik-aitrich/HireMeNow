using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_SystemUser_Id",
                table: "SavedJob");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_SystemUser_systemUserId",
                table: "SavedJob",
                column: "systemUserId",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_SystemUser_systemUserId",
                table: "SavedJob");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_SystemUser_Id",
                table: "SavedJob",
                column: "Id",
                principalTable: "SystemUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
