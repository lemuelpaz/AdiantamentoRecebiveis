using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdiantamentoRecebiveis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoEAddCarNf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notasFiscais_cart_CartId",
                table: "notasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_notasFiscais_CartId",
                table: "notasFiscais");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "notasFiscais");

            migrationBuilder.CreateTable(
                name: "cartNf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotasFiscaisId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartNf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartNf_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartNf_notasFiscais_NotasFiscaisId",
                        column: x => x.NotasFiscaisId,
                        principalTable: "notasFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartNf_CartId",
                table: "cartNf",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartNf_NotasFiscaisId",
                table: "cartNf",
                column: "NotasFiscaisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartNf");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "notasFiscais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notasFiscais_CartId",
                table: "notasFiscais",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_notasFiscais_cart_CartId",
                table: "notasFiscais",
                column: "CartId",
                principalTable: "cart",
                principalColumn: "Id");
        }
    }
}
