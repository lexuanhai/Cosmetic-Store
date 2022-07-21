using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBSITE.Migrations
{
    public partial class CrateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSizeProduct_Colors_AppSizeId",
                table: "AppSizeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Alt",
                table: "ImagesProduct");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImagesProduct");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "ImagesProduct");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "AppSize");

            migrationBuilder.AddColumn<int>(
                name: "AppImageId",
                table: "ImagesProduct",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSize",
                table: "AppSize",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesProduct_AppImageId",
                table: "ImagesProduct",
                column: "AppImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSizeProduct_AppSize_AppSizeId",
                table: "AppSizeProduct",
                column: "AppSizeId",
                principalTable: "AppSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesProduct_AppImages_AppImageId",
                table: "ImagesProduct",
                column: "AppImageId",
                principalTable: "AppImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSizeProduct_AppSize_AppSizeId",
                table: "AppSizeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesProduct_AppImages_AppImageId",
                table: "ImagesProduct");

            migrationBuilder.DropTable(
                name: "AppImages");

            migrationBuilder.DropIndex(
                name: "IX_ImagesProduct_AppImageId",
                table: "ImagesProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSize",
                table: "AppSize");

            migrationBuilder.DropColumn(
                name: "AppImageId",
                table: "ImagesProduct");

            migrationBuilder.RenameTable(
                name: "AppSize",
                newName: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "ImagesProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImagesProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ImagesProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSizeProduct_Colors_AppSizeId",
                table: "AppSizeProduct",
                column: "AppSizeId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
