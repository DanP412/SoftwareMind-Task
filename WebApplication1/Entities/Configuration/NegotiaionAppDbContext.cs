using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Users;

namespace NegotiationApp.Data.Entities.Configuration
{
    public class NegotiaionAppDbContext: DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Emoployee> Emoployees { get; set; }

        public NegotiaionAppDbContext() : base()
        {
            
        }

        public NegotiaionAppDbContext(DbContextOptions<NegotiaionAppDbContext> options): base(options)
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

            modelBuilder.Entity<Emoployee>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Employees");
                entityTypeBuilder.HasKey(u => u.Id);
            });
        }
    }
}
