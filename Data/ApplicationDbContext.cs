using Microsoft.EntityFrameworkCore;
using tourismApp.Models.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> User { get; set; }
    public DbSet <Atraction> Atraction { get; set; }
    public DbSet <Itinerary > Itinerary { get; set; }
    public DbSet <Promotion> Promotion { get; set; }

}

