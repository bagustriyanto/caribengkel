using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Credentials> Credentials { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMap> RoleMap { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<TrBooking> TrBooking { get; set; }
        public virtual DbSet<TrProduct> TrProduct { get; set; }
        public virtual DbSet<TrServicePackage> TrServicePackage { get; set; }
        public virtual DbSet<TrServicePackageDetail> TrServicePackageDetail { get; set; }

        // Unable to generate entity type for table 'public.tr_product_detail'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=caribengkel;Username=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Credentials>(entity =>
            {
                entity.ToTable("credentials");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owner");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasColumnName("identity_number")
                    .HasMaxLength(50);

                entity.Property(e => e.IdentityType).HasColumnName("identity_type");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("parameter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(5);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<RoleMap>(entity =>
            {
                entity.ToTable("role_map");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.CredentialId).HasColumnName("credential_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.RoleMap)
                    .HasForeignKey(d => d.CredentialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_map_credentials_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMap)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_map_role_fk");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.CloseDay)
                    .HasColumnName("close_day")
                    .HasMaxLength(10);

                entity.Property(e => e.CloseTime)
                    .HasColumnName("close_time")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.IdOwner).HasColumnName("id_owner");

                entity.Property(e => e.IsClose)
                    .HasColumnName("is_close")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Maps)
                    .HasColumnName("maps")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.OpenDay)
                    .HasColumnName("open_day")
                    .HasMaxLength(10);

                entity.Property(e => e.OpenTime)
                    .HasColumnName("open_time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.IdOwner)
                    .HasConstraintName("owner_store_owner_fk");
            });

            modelBuilder.Entity<TrBooking>(entity =>
            {
                entity.ToTable("tr_booking");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdStore).HasColumnName("id_store");

                entity.Property(e => e.IdVehicleBrand).HasColumnName("id_vehicle_brand");

                entity.Property(e => e.IdVehicleType).HasColumnName("id_vehicle_type");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Problem).HasColumnName("problem");

                entity.Property(e => e.QueueNumber)
                    .HasColumnName("queue_number")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.VehicleNumber)
                    .IsRequired()
                    .HasColumnName("vehicle_number")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<TrProduct>(entity =>
            {
                entity.ToTable("tr_product");

                entity.ForNpgsqlHasComment("table ini digunakan untuk menyimpan daftar sparepart dan jasa yang tersedia pada toko");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.IdStore).HasColumnName("id_store");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Stock)
                    .IsRequired()
                    .HasColumnName("stock")
                    .HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdStoreNavigation)
                    .WithMany(p => p.TrProduct)
                    .HasForeignKey(d => d.IdStore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tr_product_store_fk");
            });

            modelBuilder.Entity<TrServicePackage>(entity =>
            {
                entity.ToTable("tr_service_package");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.IdStore).HasColumnName("id_store");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdStoreNavigation)
                    .WithMany(p => p.TrServicePackage)
                    .HasForeignKey(d => d.IdStore)
                    .HasConstraintName("service_package_owner_store_fk");
            });

            modelBuilder.Entity<TrServicePackageDetail>(entity =>
            {
                entity.ToTable("tr_service_package_detail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedHost)
                    .HasColumnName("created_host")
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.IdItemType).HasColumnName("id_item_type");

                entity.Property(e => e.IdServicePackage).HasColumnName("id_service_package");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedHost)
                    .HasColumnName("modified_host")
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnName("modified_on");

                entity.HasOne(d => d.IdServicePackageNavigation)
                    .WithMany(p => p.TrServicePackageDetail)
                    .HasForeignKey(d => d.IdServicePackage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service_package_detail_service_package_fk");
            });
        }
    }
}
