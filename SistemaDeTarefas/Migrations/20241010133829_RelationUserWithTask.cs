using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class RelationUserWithTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "usuario",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "usuario",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "usuario",
                newName: "Id");
        }
    }
}
