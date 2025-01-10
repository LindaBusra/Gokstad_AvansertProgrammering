using TodoApplikasjonDel2.Models;
using Microsoft.EntityFrameworkCore;

public class TodoAppDbContext : DbContext           //DbContext er klassen som brukes for å koble til databasen.
{


     // Konstruktør: Tar inn opsjoner for databasen og sender de til baseklassen (DbContext)
    public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) {}


     // Oppretter en tabell (DbSet) for Todo-objekter i databasen
    public DbSet<Todo> Todos {get; set;}        //DbSet<Todo> Todos oppretter en tabell for å lagre todo oppgaver.


    // Konfigurerer modellen når databasen opprettes
    protected override void OnModelCreating(ModelBuilder builder)   //OnModelCreating brukes for å legge til startdata i databasen.
    {
        // Legger til noen standarddata i Todo-tabellen
        
        builder.Entity<Todo>().HasData(
        new Todo {Id = 1, Title = "Todo Oppgave-1", Description="Description for Todo Oppgave-1", IsCompleted=false},
        new Todo {Id = 2, Title = "Todo Oppgave-2", Description ="Description for Todo Oppgave-2", IsCompleted=false},
        new Todo {Id = 3, Title = "Todo Oppgave-3", Description ="Description for Todo Oppgave-3", IsCompleted=false}
        );
        
    }

}   