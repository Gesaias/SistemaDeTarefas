using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AlterTarefaNameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tarefa",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tarefa",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tarefa",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tarefa",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "usuario_id",
                table: "tarefa",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_usuario_id",
                table: "tarefa",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tarefa_usuario_usuario_id",
                table: "tarefa",
                column: "usuario_id",
                principalTable: "usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tarefa_usuario_usuario_id",
                table: "tarefa");

            migrationBuilder.DropIndex(
                name: "IX_tarefa_usuario_id",
                table: "tarefa");

            migrationBuilder.DropColumn(
                name: "usuario_id",
                table: "tarefa");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "tarefa",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tarefa",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "tarefa",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tarefa",
                newName: "Id");
        }
    }
}
