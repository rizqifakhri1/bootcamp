// namespace DatabaseZero;
using Microsoft.EntityFrameworkCore;

// namespace Database;

public class Database : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ./Database");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryID);
            cat.Property(c => c.CategoryName).HasColumnType("TEXT");
            cat.HasMany<Product>(c => c.Products).WithOne(p => p.Category);
        });

        modelBuilder.Entity<Product>(prod =>
        {
            prod.HasKey(p => p.ProductID);
            prod.Property(p => p.ProductName).HasColumnType("TEXT");
            prod.Property(p=>p.Price).IsRequired(false);
        });
    }


}
