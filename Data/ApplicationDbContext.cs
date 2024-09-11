using Microsoft.EntityFrameworkCore;
using tourismApp.Data;  

public class ApplicationDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(@"Host=${DB_LOCALHOST};Database=${DB_NAME};Port={DB_PORT};Username=${DB_NAME};Password=${DB_PASSWORD};");
        }
    }
}

