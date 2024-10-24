using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdiantamentoRecebiveis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corporates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturamentoMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoRamo = table.Column<int>(type: "int", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corporates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cart_corporates_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "corporates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CorporateId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notasFiscais_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notasFiscais_corporates_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "corporates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_CorporateId",
                table: "cart",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_notasFiscais_CartId",
                table: "notasFiscais",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_notasFiscais_CorporateId",
                table: "notasFiscais",
                column: "CorporateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notasFiscais");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "corporates");
        }
    }
}
