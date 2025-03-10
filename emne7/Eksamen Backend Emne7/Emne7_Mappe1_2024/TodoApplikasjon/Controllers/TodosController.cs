//Klassens hovedformål er å administrere en liste over "todo"-oppgaver gjennom en web API. Her er noen nøkkelfunksjoner:

using TodoApplikasjon.Models;
using Microsoft.AspNetCore.Mvc;
using Todo = TodoApplikasjon.Models.Todo;

namespace TodoApplikasjon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TodosController : ControllerBase
    {
        public static List<Todo> todos = new List<Todo>
        {
            new Todo {Id=1, Title="Todo1", Description="Create a home page", IsCompleted=true},
            new Todo {Id=2, Title="Todo2", Description="Create about us page", IsCompleted=true}
        };   
        
 

    //GET /api/todos: Hent alle Todo-oppgaver.   200:status code
    [HttpGet]
    public ActionResult<IEnumerable<Todo>> GetTodos()
    {
        return Ok(todos);
    }

    //GET /api/todos/{id}: Hent en spesifikk Todo-oppgave basert på ID.   200:status code
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Todo>> GetTodoById(int id)
    {
        var todo = todos.FirstOrDefault (b => b.Id == id) ;
        if(todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }


    //POST /api/todos: Opprett en ny Todo-oppgave.   201:status code
    [HttpPost]
    public ActionResult<Todo> CreateTodo(Todo newTodo)
    
    {
        if (!ModelState.IsValid)  
        {
        return BadRequest(ModelState);  // this returns 400 Bad Request and error details
        }

        newTodo.Id = todos.Max(b => b.Id )+1;
        todos.Add(newTodo);
        return CreatedAtAction(nameof(GetTodoById), new { id = newTodo.Id }, newTodo);
    }



    //PUT /api/todos/{id}: Oppdater en Todo-oppgave basert på ID.   204:status code
    [HttpPut("{id}")]
    public ActionResult UpdateTodo(int id, Todo updateTodo)
    {

        var existingTodo = todos.FirstOrDefault (b => b.Id == id);
        if(existingTodo == null)
        {
            return NotFound();
        }
        existingTodo.Title = updateTodo.Title;
        existingTodo.Description = updateTodo.Description;
        existingTodo.IsCompleted = updateTodo.IsCompleted;
        return NoContent();
    }


    //DELETE /api/todos/{id}: Slett en Todo-oppgave basert på ID.  204:status code
    [HttpDelete("{id}")]
    public ActionResult DeleteTodo(int id)
    {
        var todo = todos.FirstOrDefault(b=>b.Id==id);
        if(todo == null)
        {
            return NotFound();
        }

        todos.Remove(todo);
        return NoContent();
    }


    }
}