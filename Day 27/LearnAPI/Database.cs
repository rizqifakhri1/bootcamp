using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Database : DbContext
{
    public Database(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryID);
            cat.Property(c => c.Description).HasColumnType("TEXT");
            cat.HasMany(c => c.Products).WithOne(p => p.Category);
        });

        modelBuilder.Entity<Product>(cat =>
        {
            cat.HasKey(c => c.ProductID);
            cat.Property(c => c.Description).HasColumnType("TEXT");
            cat.Property(c => c.Price).IsRequired(false);
        });
    }
}