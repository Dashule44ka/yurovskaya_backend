using Microsoft.EntityFrameworkCore; //

namespace yurovskaya_backend.Models
{
    public class DizContext : DbContext //
    {
        public DizContext(DbContextOptions<DizContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        */

        public DbSet<order> Orders { get; set; } // здесь вместо book название своего класса

        public DbSet<client> Clients { get; set; } //
    }
}