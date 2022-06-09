using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication10.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
        
        
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var stringValueConverter = new StringListToJsonValueConverter();

        modelBuilder
            .Entity<Movie>()
            .Property(e => e.Genres)
            .HasConversion(stringValueConverter);
            
        modelBuilder
            .Entity<Movie>()
            .Property(p => p.Poster)
            .HasColumnType("MediumBlob");

        modelBuilder
            .Entity<Reservation>()
            .HasMany(p => p.Seats)
            .WithMany(z => z.Reservations);


    }
}