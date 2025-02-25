using Lecture4.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController] // Indikerer at denne klassen er en API-kontroller
[Route("api/[controller]")] // Definerer ruten for API-kontrolleren, basert på klassenavnet (Users)

public class UsersController :  ControllerBase
{
    private readonly AppDbContext _context;

    // Konstruktør: Kobler til databasen ved hjelp av AppDbContext
    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]                                   // Håndterer HTTP GET-forespørsel for å hente alle brukere
    public IActionResult GetAll()
    {
        return Ok(_context.Users.ToList());     // Returnerer en liste med alle brukere
    }


    [HttpGet("{id}")]                           // Håndterer HTTP GET-forespørsel for å hente en bruker basert på ID
    public IActionResult GetById(int id)  
    
    {
        var user = _context.Users.Find(id);     // Søker etter en bruker med gitt ID
        if (user == null) NotFound();           // Returnerer 404 hvis brukeren ikke finnes
        return Ok(user);                        // Returnerer brukeren
    }


    [HttpPost]                                  // Håndterer HTTP POST-forespørsel for å opprette en ny bruker
    public IActionResult Create(User user)
    {
        _context.Users.Add(user);               // Legger til brukeren i databasen
        _context.SaveChanges();                 // Lagrer endringene i databasen
        return Ok();                            // Returnerer en suksessrespons
    }


    [HttpPut("{id}")]                            // Håndterer HTTP PUT-forespørsel for å oppdatere en eksisterende bruker
    public IActionResult Update(int id, User newUser)
    {
        var user = _context.Users.Find(id);     // Søker etter brukeren med gitt ID
        if (user == null) NotFound();           // Returnerer 404 hvis brukeren ikke finnes
    
        user.Name = newUser.Name;               // Oppdaterer brukerens navn
        user.Email = newUser.Email;             // Oppdaterer brukerens epost
        _context.SaveChanges();                 // Lagrer endringene i databsen

        return NoContent();                     // Returnerer 204 No Content som respons
    }


    [HttpDelete("{id}")]                        // Håndterer HTTP DELETE-forespørsel for å slette en bruker
       public IActionResult Delete(int id)      
    {
       var user = _context.Users.Find(id);      // Søker etter brukeren med gitt ID
       if (user == null) NotFound();            // Returnerer 404 hvis brukeren ikke finnes

        _context.Users.Remove(user);            // Fjerner brukeren fra databasen
       _context.SaveChanges();                  // Lagrer endringene i databsen

       return Ok();                             // Returnerer en suksessrespons       
    }



}