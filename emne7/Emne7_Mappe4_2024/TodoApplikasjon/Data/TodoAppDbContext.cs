using TodoApplikasjon.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApplikasjon.Data
{
public class TodoAppDbContext : DbContext           //DbContext er klassen som brukes for å koble til databasen.
{


     // Konstruktør: Tar inn opsjoner for databasen og sender de til baseklassen (DbContext)
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) {}


     // Oppretter en tabell (DbSet) for Todo-objekter i databasen
    public DbSet<Todo> Todos {get; set;}        //DbSet<Todo> Todos oppretter en tabell for å lagre todo oppgaver.

    public DbSet<Category> Categories { get; set; }

    // Konfigurerer modellen når databasen opprettes
    protected override void OnModelCreating(ModelBuilder modelBuilder)   //OnModelCreating brukes for å legge til startdata i databasen.
    {
            // Relasjon en kategori kan ha mange todos oppgaver
            modelBuilder.Entity<Category>() 
                .HasMany(a => a.Todos)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);
        
    }

}   
}