using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisONG.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoUso_ProdutosInsumos_ProdutoInsumoId",
                table: "HistoricoUso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricoUso",
                table: "HistoricoUso");

            migrationBuilder.RenameTable(
                name: "HistoricoUso",
                newName: "HistoricosDeUso");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoUso_ProdutoInsumoId",
                table: "HistoricosDeUso",
                newName: "IX_HistoricosDeUso_ProdutoInsumoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricosDeUso",
                table: "HistoricosDeUso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricosDeUso_ProdutosInsumos_ProdutoInsumoId",
                table: "HistoricosDeUso",
                column: "ProdutoInsumoId",
                principalTable: "ProdutosInsumos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricosDeUso_ProdutosInsumos_ProdutoInsumoId",
                table: "HistoricosDeUso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricosDeUso",
                table: "HistoricosDeUso");

            migrationBuilder.RenameTable(
                name: "HistoricosDeUso",
                newName: "HistoricoUso");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricosDeUso_ProdutoInsumoId",
                table: "HistoricoUso",
                newName: "IX_HistoricoUso_ProdutoInsumoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricoUso",
                table: "HistoricoUso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoUso_ProdutosInsumos_ProdutoInsumoId",
                table: "HistoricoUso",
                column: "ProdutoInsumoId",
                principalTable: "ProdutosInsumos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
