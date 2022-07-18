using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBSITE.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_StaffId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ColorsProduct");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avartar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSizeProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    AppSizeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSizeProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSizeProduct_Colors_AppSizeId",
                        column: x => x.AppSizeId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppSizeProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Avartar = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSizeProduct_AppSizeId",
                table: "AppSizeProduct",
                column: "AppSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSizeProduct_ProductId",
                table: "AppSizeProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUser_StaffId",
                table: "Orders",
                column: "StaffId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUser_StaffId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppSizeProduct");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avartar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Users",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "varchar(12)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ColorsProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_StaffId",
                table: "Orders",
                column: "StaffId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
