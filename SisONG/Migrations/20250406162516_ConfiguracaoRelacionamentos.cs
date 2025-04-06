using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisONG.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracaoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Eventos_HistoricoParticipacaoId",
                table: "EventoVoluntario");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Usuarios_VoluntariosInscritosId",
                table: "EventoVoluntario");

            migrationBuilder.RenameColumn(
                name: "VoluntariosInscritosId",
                table: "EventoVoluntario",
                newName: "VoluntarioId");

            migrationBuilder.RenameColumn(
                name: "HistoricoParticipacaoId",
                table: "EventoVoluntario",
                newName: "EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_EventoVoluntario_VoluntariosInscritosId",
                table: "EventoVoluntario",
                newName: "IX_EventoVoluntario_VoluntarioId");

            migrationBuilder.AddColumn<string>(
                name: "HistoricoParticipacao",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Eventos_EventoId",
                table: "EventoVoluntario");

            migrationBuilder.DropForeignKey(
                name: "FK_EventoVoluntario_Usuarios_VoluntarioId",
                table: "EventoVoluntario");

            migrationBuilder.DropColumn(
                name: "HistoricoParticipacao",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "VoluntarioId",
                table: "EventoVoluntario",
                newName: "VoluntariosInscritosId");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "EventoVoluntario",
                newName: "HistoricoParticipacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_EventoVoluntario_VoluntarioId",
                table: "EventoVoluntario",
                newName: "IX_EventoVoluntario_VoluntariosInscritosId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntario_Eventos_HistoricoParticipacaoId",
                table: "EventoVoluntario",
                column: "HistoricoParticipacaoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventoVoluntario_Usuarios_VoluntariosInscritosId",
                table: "EventoVoluntario",
                column: "VoluntariosInscritosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
