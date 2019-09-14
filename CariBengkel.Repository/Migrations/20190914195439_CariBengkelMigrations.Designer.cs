﻿// <auto-generated />
using System;
using CariBengkel.Repository.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CariBengkel.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190914195439_CariBengkelMigrations")]
    partial class CariBengkelMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Credentials", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(255);

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("credentials");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(10);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnName("identity_number")
                        .HasMaxLength(50);

                    b.Property<int>("IdentityType")
                        .HasColumnName("identity_type");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("owner");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.OwnerStore", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(100);

                    b.Property<string>("CloseDay")
                        .HasColumnName("close_day")
                        .HasMaxLength(10);

                    b.Property<TimeSpan?>("CloseTime")
                        .HasColumnName("close_time")
                        .HasColumnType("time without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<long>("IdOwner")
                        .HasColumnName("id_owner");

                    b.Property<bool?>("IsClose")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_close")
                        .HasDefaultValueSql("false");

                    b.Property<string>("Maps")
                        .HasColumnName("maps")
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("OpenDay")
                        .HasColumnName("open_day")
                        .HasMaxLength(10);

                    b.Property<TimeSpan?>("OpenTime")
                        .HasColumnName("open_time")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdOwner");

                    b.ToTable("owner_store");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(5);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasColumnType("character varying");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("parameter");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<bool>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.RoleMap", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CredentialId")
                        .HasColumnName("credential_id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("CredentialId");

                    b.HasIndex("RoleId");

                    b.ToTable("role_map");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<long>("IdStore")
                        .HasColumnName("id_store");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("IdStore");

                    b.ToTable("service");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.ServicePackage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int?>("Discount")
                        .HasColumnName("discount");

                    b.Property<long?>("IdStore")
                        .HasColumnName("id_store");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdStore");

                    b.ToTable("service_package");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.ServicePackageDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<long?>("IdItemType")
                        .HasColumnName("id_item_type");

                    b.Property<long>("IdServicePackage")
                        .HasColumnName("id_service_package");

                    b.Property<long>("Item")
                        .HasColumnName("item");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.HasKey("Id");

                    b.HasIndex("IdServicePackage");

                    b.ToTable("service_package_detail");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Sparepart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(10);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<long>("IdMerk")
                        .HasColumnName("id_merk");

                    b.Property<long>("IdStore")
                        .HasColumnName("id_store");

                    b.Property<long>("IdVehicleType")
                        .HasColumnName("id_vehicle_type");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("money");

                    b.Property<int>("Stock")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.HasIndex("IdStore");

                    b.ToTable("sparepart");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.TransactionBooking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(15);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedHost")
                        .HasColumnName("created_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<long>("IdCustomer")
                        .HasColumnName("id_customer");

                    b.Property<long>("IdVehicleBrand")
                        .HasColumnName("id_vehicle_brand");

                    b.Property<long>("IdVehicleType")
                        .HasColumnName("id_vehicle_type");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedHost")
                        .HasColumnName("modified_host")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnName("modified_on");

                    b.Property<string>("Problem")
                        .HasColumnName("problem");

                    b.Property<string>("Remarks")
                        .HasColumnName("remarks");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasColumnName("vehicle_number")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("transaction_booking");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.OwnerStore", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.Owner", "IdOwnerNavigation")
                        .WithMany("OwnerStore")
                        .HasForeignKey("IdOwner")
                        .HasConstraintName("owner_store_owner_fk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.RoleMap", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.Credentials", "Credential")
                        .WithMany("RoleMap")
                        .HasForeignKey("CredentialId")
                        .HasConstraintName("role_map_credentials_fk");

                    b.HasOne("CariBengkel.Repository.Entity.Model.Role", "Role")
                        .WithMany("RoleMap")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("role_map_role_fk");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Service", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.OwnerStore", "IdStoreNavigation")
                        .WithMany("Service")
                        .HasForeignKey("IdStore")
                        .HasConstraintName("service_owner_store_fk");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.ServicePackage", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.OwnerStore", "IdStoreNavigation")
                        .WithMany("ServicePackage")
                        .HasForeignKey("IdStore")
                        .HasConstraintName("service_package_owner_store_fk");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.ServicePackageDetail", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.ServicePackage", "IdServicePackageNavigation")
                        .WithMany("ServicePackageDetail")
                        .HasForeignKey("IdServicePackage")
                        .HasConstraintName("service_package_detail_service_package_fk");
                });

            modelBuilder.Entity("CariBengkel.Repository.Entity.Model.Sparepart", b =>
                {
                    b.HasOne("CariBengkel.Repository.Entity.Model.OwnerStore", "IdStoreNavigation")
                        .WithMany("Sparepart")
                        .HasForeignKey("IdStore")
                        .HasConstraintName("sparepart_owner_store_fk");
                });
#pragma warning restore 612, 618
        }
    }
}
