using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisONG.Migrations
{
    /// <inheritdoc />
    public partial class AddEventoVoluntarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Eventos_EventoId",
                table: "EventoVoluntario");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Usuarios_VoluntarioId",
                table: "EventoVoluntario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoVoluntario",
                table: "EventoVoluntario");

            migrationBuilder.RenameTable(
                name: "EventoVoluntario",
                newName: "EventoVoluntarios");

            migrationBuilder.RenameIndex(
                name: "IX_EventoVoluntario_VoluntarioId",
                table: "EventoVoluntarios",
                newName: "IX_EventoVoluntarios_VoluntarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoVoluntarios",
                table: "EventoVoluntarios",
                columns: new[] { "EventoId", "VoluntarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntarios_Eventos_EventoId",
                table: "EventoVoluntarios",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntarios_Usuarios_VoluntarioId",
                table: "EventoVoluntarios",
                column: "VoluntarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntarios_Eventos_EventoId",
                table: "EventoVoluntarios");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntarios_Usuarios_VoluntarioId",
                table: "EventoVoluntarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoVoluntarios",
                table: "EventoVoluntarios");

            migrationBuilder.RenameTable(
                name: "EventoVoluntarios",
                newName: "EventoVoluntario");

            migrationBuilder.RenameIndex(
                name: "IX_EventoVoluntarios_VoluntarioId",
                table: "EventoVoluntario",
                newName: "IX_EventoVoluntario_VoluntarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoVoluntario",
                table: "EventoVoluntario",
                columns: new[] { "EventoId", "VoluntarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntario_Eventos_EventoId",
                table: "EventoVoluntario",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntario_Usuarios_VoluntarioId",
                table: "EventoVoluntario",
                column: "VoluntarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
