using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Entities;


namespace PhoneStoreDAL.Contexts
{
    public class PhoneStoreDBContext : DbContext
    {
        string stcon;
        public PhoneStoreDBContext()
        {
            stcon = ConfigurationManager.ConnectionStrings["strPhoneStoreDB"].ConnectionString;
        }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ImeiUnit> ImeiUnits { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
        public DbSet<WarrantyTicket> WarrantyTickets { get; set; }
        public DbSet<WarrantyStatusLog> WarrantyStatusLogs { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(stcon);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductVariant>()
                .HasIndex(x => x.Sku)
                .IsUnique();

            modelBuilder.Entity<ImeiUnit>()
                .HasKey(x => x.Imei);

            modelBuilder.Entity<SalesInvoiceDetail>()
                .HasOne(d => d.ImeiUnit)
                .WithMany()
                .HasForeignKey(d => d.Imei)
                .HasPrincipalKey(i => i.Imei)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WarrantyTicket>()
                .HasOne(w => w.ImeiUnit)
                .WithMany()
                .HasForeignKey(w => w.Imei)
                .HasPrincipalKey(i => i.Imei)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImeiUnit>()
                .HasOne(i => i.ReceivedInPurchaseInvoice)
                .WithMany()
                .HasForeignKey(i => i.ReceivedInPurchaseInvoiceId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<UserAccount>()
                .HasIndex(x => x.Username)
                .IsUnique();

        }

    }
}
