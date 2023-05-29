using Microsoft.EntityFrameworkCore; //
using NuGet.LibraryModel;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Models
{
    public class DizContext : DbContext //
    {
        public DizContext(DbContextOptions<DizContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Diz>().HasMany(lib => lib.order).WithMany();
        }

        public DbSet<yurovskaya_backend.Models.client> client { get; set; }
        public DbSet<yurovskaya_backend.Models.order> order { get; set; }
        public DbSet<yurovskaya_backend.Models.Diz> Diz { get; set; } = default!;
        public DbSet<yurovskaya_backend.Models.user> user { get; set; } = default!;
        
    }
}