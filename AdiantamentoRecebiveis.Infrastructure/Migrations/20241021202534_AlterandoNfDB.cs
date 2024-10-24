using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdiantamentoRecebiveis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNfDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "notasFiscais",
                newName: "ValorBruto");

            migrationBuilder.AddColumn<decimal>(
                name: "Desagio",
                table: "notasFiscais",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prazo",
                table: "notasFiscais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxa",
                table: "notasFiscais",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desagio",
                table: "notasFiscais");

            migrationBuilder.DropColumn(
                name: "Prazo",
                table: "notasFiscais");

            migrationBuilder.DropColumn(
                name: "Taxa",
                table: "notasFiscais");

            migrationBuilder.RenameColumn(
                name: "ValorBruto",
                table: "notasFiscais",
                newName: "Valor");
        }
    }
}
