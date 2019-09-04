using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CariBengkel.Repository.Migrations
{
    public partial class v1_MigrationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "owner",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_host",
                table: "owner",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_on",
                table: "owner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "owner",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modified_host",
                table: "owner",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_on",
                table: "owner",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    phone = table.Column<string>(maxLength: 15, nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 20, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parameter",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    code = table.Column<string>(maxLength: 5, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 20, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "parameter");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "owner");

            migrationBuilder.DropColumn(
                name: "created_host",
                table: "owner");

            migrationBuilder.DropColumn(
                name: "created_on",
                table: "owner");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "owner");

            migrationBuilder.DropColumn(
                name: "modified_host",
                table: "owner");

            migrationBuilder.DropColumn(
                name: "modified_on",
                table: "owner");
        }
    }
}
