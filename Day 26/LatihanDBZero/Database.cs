// namespace LatihanDBZero;
using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Model> Models { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ./Database.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model>(model =>
        {
            model.HasKey(m => m.ModelID);
            model.Property(m => m.ModelName).HasColumnType("TEXT");
            model.HasMany<Car>(m => m.Cars).WithOne(c => c.Model);
        });

        modelBuilder.Entity<Car>(car =>
        {
            car.HasKey(c => c.CarID);
            car.Property(c => c.CarName).HasColumnType("TEXT");
        });

        
    }
}
