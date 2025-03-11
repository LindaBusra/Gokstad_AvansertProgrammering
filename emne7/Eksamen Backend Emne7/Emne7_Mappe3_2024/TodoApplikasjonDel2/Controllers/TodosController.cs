using TodoApplikasjonDel2.Models;
using Microsoft.AspNetCore.Mvc;


[ApiController] // Indikerer at denne klassen er en API-kontroller
[Route("api/[controller]")] // Definerer ruten for API-kontrolleren, basert på klassenavnet (Todo)

public class TodosController : ControllerBase
{

    private readonly TodoAppDbContext _context;

    // Konstruktør: Kobler til databasen ved hjelp av AppDbContext
    public TodosController(TodoAppDbContext context)
    {
        _context = context;
    }



    //GET /api/todos: Hent alle Todo-oppgaver.
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Todos.ToList());     // Returnerer en liste med alle todo oppgaver
    }



    //GET /api/todos/{id}: Hent en spesifikk Todo-oppgave basert på ID.
    [HttpGet("{id}")]
    public IActionResult GetById(int id)

    {
        var todo = _context.Todos.Find(id);     // Søker etter en todo oppgave med gitt ID
        if (todo == null) NotFound();           // Returnerer 404 hvis todo oppgaven ikke finnes
        return Ok(todo);                        // Returnerer todo oppgaven
    }


    //POST /api/todos: Opprett en ny Todo-oppgave.
    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        _context.Todos.Add(todo);               // Legger til todo oppgaven i databasen
        _context.SaveChanges();                 // Lagrer endringene i databasen
        return Ok();                            // Returnerer en suksessrespons
    }



    //PUT /api/todos/{id}: Oppdater en Todo-oppgave basert på ID.
    [HttpPut("{id}")]
    public IActionResult Update(int id, Todo newTodo)
    {
        var todo = _context.Todos.Find(id);     // Søker etter todo oppgaven med gitt ID
        if (todo == null) NotFound();           // Returnerer 404 hvis todo oppgaven ikke finnes

        todo.Title = newTodo.Title;             // Oppdaterer todo oppgave sin title
        todo.Description = newTodo.Description; // Oppdaterer todo oppgave sin description
        todo.IsCompleted = newTodo.IsCompleted; // Oppdatterer verdien isCompleted
        _context.SaveChanges();                 // Lagrer endringene i databasen

        return NoContent();                     // Returnerer 204 No Content som respons
    }


    //DELETE /api/todos/{id}: Slett en Todo-oppgave basert på ID.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);      // Søker etter todo oppgaven med gitt ID
        if (todo == null) NotFound();            // Returnerer 404 hvis todo oppgaven ikke finnes

        _context.Todos.Remove(todo);            // Fjerner todo oppgaven fra databasen
        _context.SaveChanges();                  // Lagrer endringene i databsen

        return Ok();                             // Returnerer en suksessrespons       
    }
}