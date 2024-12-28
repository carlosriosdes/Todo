using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Todo",
                newName: "PendingApproval");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PendingApproval",
                table: "Todo",
                newName: "IsCompleted");
        }
    }
}
