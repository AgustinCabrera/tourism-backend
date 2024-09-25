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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de relación muchos a muchos entre Itinerary y Attraction
        modelBuilder.Entity<ItineraryAtraction>()
            .HasKey(ia => new { ia.ItineraryId, ia.AtractionId });

        modelBuilder.Entity<ItineraryAtraction>()
            .HasOne(ia => ia.Itinerary)
            .WithMany(i => i.ItineraryAtractions)
            .HasForeignKey(ia => ia.ItineraryId);

        modelBuilder.Entity<ItineraryAtraction>()
            .HasOne(ia => ia.Atraction)
            .WithMany(a => a.ItineraryAtractions)
            .HasForeignKey(ia => ia.AtractionId);

        // Configuración de relación muchos a muchos entre Itinerary y Promotion
        modelBuilder.Entity<ItineraryPromotion>()
            .HasKey(ip => new { ip.ItineraryId, ip.PromotionId });

        modelBuilder.Entity<ItineraryPromotion>()
            .HasOne(ip => ip.Itinerary)
            .WithMany(i => i.ItineraryPromotions)
            .HasForeignKey(ip => ip.ItineraryId);

        modelBuilder.Entity<ItineraryPromotion>()
            .HasOne(ip => ip.Promotion)
            .WithMany(p => p.ItineraryPromotions)
            .HasForeignKey(ip => ip.PromotionId);
    }

}

