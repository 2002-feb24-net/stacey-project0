using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CornNuggets.Entities
{
    public partial class CornNuggetsContext : DbContext
    {
        public CornNuggetsContext()
        {
        }

        public CornNuggetsContext(DbContextOptions<CornNuggetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<NuggetStores> NuggetStores { get; set; }
        public virtual DbSet<OrderLog> OrderLog { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SecretConfiguration.CommunicationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B84A7DAEAD");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PreferredStore)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('TEXA001')");
            });

            modelBuilder.Entity<NuggetStores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__NuggetSt__3B82F0E1A715B64E");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Arlington')");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('TEXA001')");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductQty).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLog)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderLog__OrderI__489AC854");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLog)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderLog__Produc__498EEC8D");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAFE830DA85");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateTimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__45BE5BA9");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreID__44CA3770");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6ED7B515FE4");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Inventory).HasDefaultValueSql("((1000))");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
namespace CornNuggets.Entities
{
    internal class SecretConfiguration
    {
        internal const string CommunicationString = "Server=tcp:2020-training-stacey.database.windows.net,1433;Initial Catalog=CornNuggets;Persist Security Info=False;User ID=stacey;Password=Umbrella123();MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    } 
}