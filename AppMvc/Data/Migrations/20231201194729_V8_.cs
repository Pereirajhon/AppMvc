using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class V8_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Stores_StoreId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CartId",
                table: "Stores",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Stores_StoreId",
                table: "Carts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Carts_CartId",
                table: "Stores",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Stores_StoreId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Carts_CartId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CartId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Stores_StoreId",
                table: "Carts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
