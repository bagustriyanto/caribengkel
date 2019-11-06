using Microsoft.EntityFrameworkCore.Migrations;

namespace CariBengkel.Repository.Migrations
{
    public partial class AddSaltColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "credentials",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "NULL::character varying");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "credentials");
        }
    }
}
