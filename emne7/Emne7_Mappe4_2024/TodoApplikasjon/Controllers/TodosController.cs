using TodoApplikasjon.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace TodoApplikasjon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

public class TodosController : ControllerBase
{
        
    private readonly ITodosService _todosService;


    public TodosController(ITodosService todosService)
    {
        _todosService = todosService;       // initialeserer todosService
    }
        
 

    //GET /api/todos: Hent alle Todo-oppgaver.
    [HttpGet]
    public ActionResult<IEnumerable<Todo>> GetTodos()
    {
        var todos = _todosService.GetTodos();
        return Ok(todos);
    }

    //GET /api/todos/{id}: Hent en spesifikk Todo-oppgave basert på ID.
    [HttpGet("{id}")]
    public ActionResult<Todo> GetTodo(int id)
    {
        var todo = _todosService.GetTodoById(id);
        if(todo == null)
        {
            Log.Information("Todo er null!");
            return NotFound();   // Hvis Todo ikke finnes, returner NotFound.
        }
        return Ok(todo);
    }


    //POST /api/todos: Opprett en ny Todo-oppgave.
    [HttpPost]
    public ActionResult<Todo> CreateTodo(Todo newTodo)
    
    {
        _todosService.AddTodo(newTodo);
        return CreatedAtAction(nameof(GetTodo), new { id = newTodo.Id }, newTodo);
    }



    //PUT /api/todos/{id}: Oppdater en Todo-oppgave basert på ID.
    [HttpPut("{id}")]
    public ActionResult UpdateTodo(int id, Todo updatedTodo)
    {

        var existingTodo = _todosService.GetTodoById(id); 
        if(existingTodo == null)
        {
            return NotFound();   // Returnerer 404 hvis todo ikke finnes
        }
        _todosService.UpdateTodo(id,updatedTodo);
        return NoContent();     // Returnerer 204 når oppdateringen er vellykket
    }


    //DELETE /api/todos/{id}: Slett en Todo-oppgave basert på ID.
    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(int id)
    {
        _todosService.DeleteTodo(id);
        return NoContent();     // Returnerer 204 når slettingen er vellykket
    }


    // Endpoint: Hent alle oppgaver tilhørende en spesifikk kategori
    [HttpGet("category/{categoryId}")]
    public ActionResult<IEnumerable<Todo>> GetTodosByCategory(int categoryId)
    {
        var todos = _todosService.GetTodosByCategory(categoryId);
        return Ok(todos);
    }

    // Endpoint: Finne antall Todo-oppgaver per kategori
    [HttpGet("category/{categoryId}/count")]
    public ActionResult<int> CountTodosByCategory(int categoryId)
    {
        var count = _todosService.CountTodosByCategory(categoryId);
        return Ok(count);
    }

    // Endpoint: Hente alle fullførte Todo-oppgaver med kategoriinformasjon
    [HttpGet("completed")]
    public ActionResult<IEnumerable<Todo>> GetCompletedTodosWithCategory()
    {
        var todos = _todosService.GetCompletedTodosWithCategory();
        return Ok(todos);
    }
    
    }
}