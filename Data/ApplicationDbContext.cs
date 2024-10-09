using Microsoft.EntityFrameworkCore;
using tourismApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
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
        // Llama a la configuración base de Identity para asegurarse de que las entidades de Identity se configuren correctamente
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("uuid");
        });

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

        // Relación entre Itinerary y ApplicationUser
        modelBuilder.Entity<Itinerary>()
        .HasOne(i => i.User)
        .WithMany()
        .HasForeignKey(i => i.UserId)
        .OnDelete(DeleteBehavior.Cascade); ;
        }



}

