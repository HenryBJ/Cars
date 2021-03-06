using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsDbContext:DbContext
    {
        public DbSet<CarModel> Cars { get; set; }
       

        public CarsDbContext(DbContextOptions<CarsDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarModel>().ToTable("Cars");
            
            modelBuilder.Entity<CarModel>(entity=>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Marca).HasMaxLength(8);
            });
            
        }
    }
}