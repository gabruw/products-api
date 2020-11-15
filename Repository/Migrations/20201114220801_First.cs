using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Codigo = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Codigo = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Order_CustomerCodigo = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Order_Customer_Order_CustomerCodigo",
                        column: x => x.Order_CustomerCodigo,
                        principalTable: "Customer",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Codigo = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoBarras = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Valor = table.Column<double>(type: "DOUBLE", nullable: false),
                    Product_OrderCodigo = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Product_Order_Product_OrderCodigo",
                        column: x => x.Product_OrderCodigo,
                        principalTable: "Order",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Cpf",
                table: "Customer",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Order_CustomerCodigo",
                table: "Order",
                column: "Order_CustomerCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CodigoBarras",
                table: "Product",
                column: "CodigoBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_OrderCodigo",
                table: "Product",
                column: "Product_OrderCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
