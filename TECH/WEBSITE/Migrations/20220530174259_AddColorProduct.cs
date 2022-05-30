using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBSITE.Migrations
{
    public partial class AddColorProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Product_ProductId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ProductId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Colors");

            migrationBuilder.CreateTable(
                name: "ColorsProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorsProduct_ColorId",
                table: "ColorsProduct",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorsProduct_ProductId",
                table: "ColorsProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorsProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Product_ProductId",
                table: "Colors",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
