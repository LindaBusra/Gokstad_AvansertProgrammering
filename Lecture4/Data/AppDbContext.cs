using Lecture4.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext           //DbContext er klassen som brukes for å koble til databasen.
{


     // Konstruktør: Tar inn opsjoner for databasen og sender de til baseklassen (DbContext)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


     // Oppretter en tabell (DbSet) for User-objekter i databasen
    public DbSet<User> Users {get; set;}        //DbSet<User> Users oppretter en tabell for å lagre brukere.


    // Konfigurerer modellen når databasen opprettes
    protected override void OnModelCreating(ModelBuilder builder)   //OnModelCreating brukes for å legge til startdata i databasen (som Emily og Saly her).
    {
        // Legger til noen standarddata i User-tabellen
        
        builder.Entity<User>().HasData(
        new User {Id = 1, Name = "Emily Nilsen", Email="emily@test.no"},
        new User {Id = 2, Name = "Saly Jackson", Email ="saly@test.no"}
        );
        
    }

}   