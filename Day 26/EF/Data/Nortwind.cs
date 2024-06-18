// namespace EF.Data;

using Microsoft.EntityFrameworkCore;

public class Northwind : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Northwind.db");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>(cat =>
        {
            cat.HasMany<Product>(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);
        });
    }
}