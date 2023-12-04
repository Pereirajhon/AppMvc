using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class V12_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IphoneId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IphoneId",
                table: "Stores",
                column: "IphoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Iphones_IphoneId",
                table: "Stores",
                column: "IphoneId",
                principalTable: "Iphones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Iphones_IphoneId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_IphoneId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IphoneId",
                table: "Stores");
        }
    }
}
