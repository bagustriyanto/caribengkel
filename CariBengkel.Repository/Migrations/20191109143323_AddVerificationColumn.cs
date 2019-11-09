using Microsoft.EntityFrameworkCore.Migrations;

namespace CariBengkel.Repository.Migrations
{
    public partial class AddVerificationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modifeid_by",
                table: "credentials",
                newName: "modified_by");

            migrationBuilder.AddColumn<string>(
                name: "verification_code",
                table: "credentials",
                type: "character varying",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "verification_code",
                table: "credentials");

            migrationBuilder.RenameColumn(
                name: "modified_by",
                table: "credentials",
                newName: "modifeid_by");
        }
    }
}
