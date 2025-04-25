using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisONG.Migrations
{
    /// <inheritdoc />
    public partial class AlterarItemDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Item",
                table: "Doacoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doacoes",
                keyColumn: "Item",
                keyValue: null,
                column: "Item",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Item",
                table: "Doacoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
