using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ToDos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserId",
                table: "ToDos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Users_UserId",
                table: "ToDos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Users_UserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_UserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDos");
        }
    }
}
