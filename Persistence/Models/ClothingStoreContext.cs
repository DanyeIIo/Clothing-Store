using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClothingStore.Models
{
    public partial class ClothingStoreContext : DbContext
    {
        public ClothingStoreContext()
        {
        }

        public ClothingStoreContext(DbContextOptions<ClothingStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DeliveryCountry> DeliveryCountries { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembersProduct> MembersProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Database=ClothingStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<DeliveryCountry>(entity =>
            {
                entity.ToTable("DeliveryCountry");

                entity.Property(e => e.Id).HasColumnName("ID");
                
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.DeliveryCountries)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_ProductsManufacturers_Products");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DeliveryCountries)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductsManufacturers_Categories");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Members__A9D1053454B5C4AE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Patronymic).HasMaxLength(35);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Roles");
            });

            modelBuilder.Entity<MembersProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembersProducts)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MembersProducts_Products");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MembersProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_MembersProducts_Categories");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Orders_Manufacturers");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Orders_Members");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Orders_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ExhibitionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<ProductsCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductsCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductsCategories_Categories");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductsCategories_Products");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
