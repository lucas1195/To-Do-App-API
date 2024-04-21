using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_API.Migrations
{
    /// <inheritdoc />
    public partial class FixInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IituloTask",
                table: "Task",
                newName: "TituloTask");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TituloTask",
                table: "Task",
                newName: "IituloTask");
        }
    }
}
