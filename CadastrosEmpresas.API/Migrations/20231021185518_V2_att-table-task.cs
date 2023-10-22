using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastrosEmpresas.API.Migrations
{
    /// <inheritdoc />
    public partial class V2_atttabletask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskName",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskName",
                table: "Tasks",
                column: "TaskName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskName",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskName",
                table: "Tasks",
                column: "TaskName",
                unique: true);
        }
    }
}
