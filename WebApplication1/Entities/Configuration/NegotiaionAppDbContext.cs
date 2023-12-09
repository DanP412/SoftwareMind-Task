using Microsoft.EntityFrameworkCore;
using NegotiationApp.Entities.Negotiations;
using NegotiationApp.Entities.Products;
using System.ComponentModel;
using WebApplication1.Models.Users;

namespace NegotiationApp.Data.Entities.Configuration
{
    public class NegotiaionAppDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Emoployees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Negotiation> Negotiations { get; set; }
        public virtual DbSet<Attempt> Attempts { get; set; }

        public NegotiaionAppDbContext() : base()
        {

        }

        public NegotiaionAppDbContext(DbContextOptions<NegotiaionAppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Customers");
                entityTypeBuilder.HasKey(u => u.Id);
            });

            modelBuilder.Entity<Employee>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Emoployees");
                entityTypeBuilder.HasKey(u => u.Id);
            });

            modelBuilder.Entity<Product>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Products");
                entityTypeBuilder.HasKey(p => p.Id);
                entityTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entityTypeBuilder.Property(p => p.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Negotiation>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Negotiations");
                entityTypeBuilder.HasKey(n => n.Id);
                entityTypeBuilder.HasOne<Product>().WithMany().HasForeignKey(n => n.ProductId);
                entityTypeBuilder.HasOne<Customer>().WithMany().HasForeignKey(n => n.CustomerId);
                entityTypeBuilder.HasOne<Employee>().WithMany().HasForeignKey(n => n.EmployeeId);
            });

            modelBuilder.Entity<Attempt>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Attempts");
                entityTypeBuilder.HasKey(a => a.Id);

                entityTypeBuilder.HasOne(a => a.Negotiation)
                .WithMany(n => n.Attempts)
                .HasForeignKey(a => a.NegotiationId)
                .OnDelete(DeleteBehavior.Restrict); 

                entityTypeBuilder.Property(a => a.Date).HasColumnType("date");
            });


            modelBuilder.Entity<Customer>().HasData(
              new Customer { Id = 1 },
              new Customer { Id = 2 }
            );

            modelBuilder.Entity<Employee>().HasData(
             new Employee { Id = 1 },
             new Employee { Id = 2 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Price = 100.00M },
                new Product { Id = 2, Name = "Product2", Price = 150.00M }
            );

            modelBuilder.Entity<Negotiation>().HasData(
                new Negotiation { Id = 1, ProductId = 1, CustomerId = 1, EmployeeId = 1, Status = "Pending" },
                new Negotiation { Id = 2, ProductId = 2, CustomerId = 2, EmployeeId = 2, Status = "Pending" }
            );

            modelBuilder.Entity<Attempt>().HasData(
                new Attempt { Id = 1, NegotiationId = 1, Date = new DateTime(2023, 1, 1) },
                new Attempt { Id = 2, NegotiationId = 2, Date = new DateTime(2023, 1, 2) }
            );
        }
    }
}
