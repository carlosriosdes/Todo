using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoStates",
                columns: table => new
                {
                    IdTodoState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoStates", x => x.IdTodoState);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    IdTodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IdTodoState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.IdTodo);
                    table.ForeignKey(
                        name: "FK_Todo_TodoStates_IdTodoState",
                        column: x => x.IdTodoState,
                        principalTable: "TodoStates",
                        principalColumn: "IdTodoState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_IdTodoState",
                table: "Todo",
                column: "IdTodoState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "TodoStates");
        }
    }
}
