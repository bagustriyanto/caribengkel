using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CariBengkel.Repository.Migrations
{
    public partial class AddUserTableAndCredentialColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "credentials",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_host",
                table: "credentials",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "credentials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modifeid_by",
                table: "credentials",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_host",
                table: "credentials",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_on",
                table: "credentials",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_credential = table.Column<long>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: true),
                    last_name = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<int>(nullable: true),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 20, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "user_fk",
                        column: x => x.id_credential,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_id_credential",
                table: "user",
                column: "id_credential");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "created_host",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "modifeid_by",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "modified_host",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "modified_on",
                table: "credentials");
        }
    }
}
