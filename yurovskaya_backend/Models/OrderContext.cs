using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore; //
using NuGet.LibraryModel;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Models
{
    public class OrderContext : DbContext //
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Order>().HasMany(lib => lib.order).WithMany();
        }

        public DbSet<yurovskaya_backend.Models.client> clients { get; set; }
        public DbSet<yurovskaya_backend.Models.Design> designs { get; set; }
        public DbSet<yurovskaya_backend.Models.Order> orders { get; set; }
        public DbSet<yurovskaya_backend.Models.user> users { get; set; }
        
    }
}