using Microsoft.EntityFrameworkCore.Migrations;

namespace CariBengkel.Repository.Migrations
{
    public partial class ChangePhoneToVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "user",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_parent",
                table: "menu",
                column: "parent");

            migrationBuilder.AddForeignKey(
                name: "fk_parent",
                table: "menu",
                column: "parent",
                principalTable: "menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parent",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_menu_parent",
                table: "menu");

            migrationBuilder.AlterColumn<int>(
                name: "phone",
                table: "user",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);
        }
    }
}
