using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CariBengkel.Repository.Migrations
{
    public partial class CariBengkelInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    status = table.Column<bool>(nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.id);
                });

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
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tr_booking",
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
                    modified_host = table.Column<string>(maxLength: 15, nullable: true),
                    id_store = table.Column<long>(nullable: false),
                    queue_number = table.Column<int>(nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_booking", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "store",
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
                    table.PrimaryKey("PK_store", x => x.id);
                    table.ForeignKey(
                        name: "owner_store_owner_fk",
                        column: x => x.id_owner,
                        principalTable: "owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_map",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<long>(nullable: false),
                    credential_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_map", x => x.id);
                    table.ForeignKey(
                        name: "role_map_credentials_fk",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "role_map_role_fk",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tr_product",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    stock = table.Column<string>(type: "character varying", nullable: false),
                    id_store = table.Column<long>(nullable: false),
                    created_by = table.Column<string>(maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(nullable: true),
                    created_host = table.Column<string>(maxLength: 15, nullable: true),
                    modified_by = table.Column<string>(maxLength: 50, nullable: true),
                    modified_time = table.Column<DateTime>(nullable: true),
                    modified_host = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_product", x => x.id);
                    table.ForeignKey(
                        name: "tr_product_store_fk",
                        column: x => x.id_store,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("Npgsql:Comment", "table ini digunakan untuk menyimpan daftar sparepart dan jasa yang tersedia pada toko");

            migrationBuilder.CreateTable(
                name: "tr_service_package",
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
                    table.PrimaryKey("PK_tr_service_package", x => x.id);
                    table.ForeignKey(
                        name: "service_package_owner_store_fk",
                        column: x => x.id_store,
                        principalTable: "store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tr_service_package_detail",
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
                    table.PrimaryKey("PK_tr_service_package_detail", x => x.id);
                    table.ForeignKey(
                        name: "service_package_detail_service_package_fk",
                        column: x => x.id_service_package,
                        principalTable: "tr_service_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_map_credential_id",
                table: "role_map",
                column: "credential_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_map_role_id",
                table: "role_map",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_id_owner",
                table: "store",
                column: "id_owner");

            migrationBuilder.CreateIndex(
                name: "IX_tr_product_id_store",
                table: "tr_product",
                column: "id_store");

            migrationBuilder.CreateIndex(
                name: "IX_tr_service_package_id_store",
                table: "tr_service_package",
                column: "id_store");

            migrationBuilder.CreateIndex(
                name: "IX_tr_service_package_detail_id_service_package",
                table: "tr_service_package_detail",
                column: "id_service_package");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "parameter");

            migrationBuilder.DropTable(
                name: "role_map");

            migrationBuilder.DropTable(
                name: "tr_booking");

            migrationBuilder.DropTable(
                name: "tr_product");

            migrationBuilder.DropTable(
                name: "tr_service_package_detail");

            migrationBuilder.DropTable(
                name: "credentials");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "tr_service_package");

            migrationBuilder.DropTable(
                name: "store");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
