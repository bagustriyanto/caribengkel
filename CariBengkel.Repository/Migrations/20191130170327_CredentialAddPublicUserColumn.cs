using Microsoft.EntityFrameworkCore.Migrations;

namespace CariBengkel.Repository.Migrations
{
    public partial class CredentialAddPublicUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "public_user",
                table: "credentials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "public_user",
                table: "credentials");
        }
    }
}
