using Microsoft.EntityFrameworkCore.Migrations;

namespace _0124ShopAppAPI.Migrations
{
    public partial class shopId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "ShopItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "ShopItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
