using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisONG.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCriacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "EventoVoluntario",
                columns: table => new
                {
                    HistoricoParticipacaoId = table.Column<int>(type: "int", nullable: false),
                    VoluntariosInscritosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoVoluntario", x => new { x.HistoricoParticipacaoId, x.VoluntariosInscritosId });
                    table.ForeignKey(
                        name: "FK_EventoVoluntario_Eventos_HistoricoParticipacaoId",
                        column: x => x.HistoricoParticipacaoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoVoluntario_Usuarios_VoluntariosInscritosId",
                        column: x => x.VoluntariosInscritosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EventoVoluntario_VoluntariosInscritosId",
                table: "EventoVoluntario",
                column: "VoluntariosInscritosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoVoluntario");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }
    }
}
