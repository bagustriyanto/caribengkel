using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CariBengkel.Repository.Migrations
{
    public partial class CariBengkelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "owner",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    phone = table.Column<string>(maxLength: 15, nullable: false),
                    identity_number = table.Column<string>(maxLength: 50, nullable: false),
                    identity_type = table.Column<int>(nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 20, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "transaction_booking",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(maxLength: 15, nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    id_customer = table.Column<long>(nullable: false),
                    id_vehicle_type = table.Column<long>(nullable: false),
                    id_vehicle_brand = table.Column<long>(nullable: false),
                    vehicle_number = table.Column<string>(maxLength: 11, nullable: false),
                    problem = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_booking", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owner_store",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_owner = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: false),
                    maps = table.Column<string>(maxLength: 100, nullable: true),
                    open_day = table.Column<string>(maxLength: 10, nullable: true),
                    open_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true),
                    close_day = table.Column<string>(maxLength: 10, nullable: true),
                    close_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true),
                    is_close = table.Column<bool>(nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner_store", x => x.id);
                    table.ForeignKey(
                        name: "owner_store_owner_fk",
                        column: x => x.id_owner,
                        principalTable: "owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true),
                    id_store = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.id);
                    table.ForeignKey(
                        name: "service_owner_store_fk",
                        column: x => x.id_store,
                        principalTable: "owner_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service_package",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true),
                    id_store = table.Column<long>(nullable: true),
                    discount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_package", x => x.id);
                    table.ForeignKey(
                        name: "service_package_owner_store_fk",
                        column: x => x.id_store,
                        principalTable: "owner_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sparepart",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(nullable: true),
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    stock = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    id_store = table.Column<long>(nullable: false),
                    id_vehicle_type = table.Column<long>(nullable: false),
                    id_merk = table.Column<long>(nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sparepart", x => x.id);
                    table.ForeignKey(
                        name: "sparepart_owner_store_fk",
                        column: x => x.id_store,
                        principalTable: "owner_store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service_package_detail",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_service_package = table.Column<long>(nullable: false),
                    item = table.Column<long>(nullable: false),
                    id_item_type = table.Column<long>(nullable: true),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_on = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_package_detail", x => x.id);
                    table.ForeignKey(
                        name: "service_package_detail_service_package_fk",
                        column: x => x.id_service_package,
                        principalTable: "service_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_owner_store_id_owner",
                table: "owner_store",
                column: "id_owner");

            migrationBuilder.CreateIndex(
                name: "IX_service_id_store",
                table: "service",
                column: "id_store");

            migrationBuilder.CreateIndex(
                name: "IX_service_package_id_store",
                table: "service_package",
                column: "id_store");

            migrationBuilder.CreateIndex(
                name: "IX_service_package_detail_id_service_package",
                table: "service_package_detail",
                column: "id_service_package");

            migrationBuilder.CreateIndex(
                name: "IX_sparepart_id_store",
                table: "sparepart",
                column: "id_store");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "parameter");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "service_package_detail");

            migrationBuilder.DropTable(
                name: "sparepart");

            migrationBuilder.DropTable(
                name: "transaction_booking");

            migrationBuilder.DropTable(
                name: "service_package");

            migrationBuilder.DropTable(
                name: "owner_store");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
