using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_UseridUser",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_UseridUser",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "UseridUser",
                table: "Task");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UseridUser",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_UseridUser",
                table: "Task",
                column: "UseridUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_UseridUser",
                table: "Task",
                column: "UseridUser",
                principalTable: "User",
                principalColumn: "idUser");
        }
    }
}
