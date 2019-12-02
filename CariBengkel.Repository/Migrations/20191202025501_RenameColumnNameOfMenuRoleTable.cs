using Microsoft.EntityFrameworkCore.Migrations;

namespace CariBengkel.Repository.Migrations
{
    public partial class RenameColumnNameOfMenuRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_role",
                table: "menu_role_map",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "id_menu",
                table: "menu_role_map",
                newName: "menu_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_role_map_id_role",
                table: "menu_role_map",
                newName: "IX_menu_role_map_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_menu_role_map_id_menu",
                table: "menu_role_map",
                newName: "IX_menu_role_map_menu_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "menu_role_map",
                newName: "id_role");

            migrationBuilder.RenameColumn(
                name: "menu_id",
                table: "menu_role_map",
                newName: "id_menu");

            migrationBuilder.RenameIndex(
                name: "IX_menu_role_map_role_id",
                table: "menu_role_map",
                newName: "IX_menu_role_map_id_role");

            migrationBuilder.RenameIndex(
                name: "IX_menu_role_map_menu_id",
                table: "menu_role_map",
                newName: "IX_menu_role_map_id_menu");
        }
    }
}
