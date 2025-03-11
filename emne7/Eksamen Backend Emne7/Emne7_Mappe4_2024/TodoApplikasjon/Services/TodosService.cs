using TodoApplikasjon.Models;
using TodoApplikasjon.Repository;
using Serilog;

//Her vi refaktorerte koden for å bruke Dependency Injection ved å flytte logikken fra TodosController til en egen tjeneste (TodosService)
public class TodosService : ITodosService
{

private readonly ITodoRepository _todoRepository;
public TodosService(ITodoRepository todoRepository)
{
    _todoRepository = todoRepository;       // Setter opp repository via Dependency Injection
}


    public IEnumerable<Todo> GetTodos() => _todoRepository.GetAllTodos().ToList();      // Henter alle todos fra repository

    public Todo? GetTodoById(int id) => _todoRepository.GetTodoById(id);                // Henter en spesifikk todo basert på id

    public void AddTodo(Todo todo){
        if(todo == null) return;
        _todoRepository.AddTodo(todo);
        Log.Information($"Todo {todo.Title} added ");
    }

    public void UpdateTodo(int id, Todo updatedTodo) 
    {
       var todo = GetTodoById(id);
       if(todo == null) return;

    //oppdaterer todo egenskaper
    todo.Title = updatedTodo.Title;
    todo.Description = updatedTodo.Description;
    todo.IsCompleted = updatedTodo.IsCompleted;
    todo.CategoryId = updatedTodo.CategoryId;

    _todoRepository.UpdateTodo(todo);       //lagrer oppdateringer
       Log.Information($"Todo {todo.Title} is updated ");       //logger handlingen
    }


    public void DeleteTodo(int id) 
    {
    var todo = GetTodoById(id);
    if (todo == null) {
        Log.Information($"No todo found with ID {id} to delete.");
        return;
    }
    
    _todoRepository.DeleteTodo(id);     //sletter todo fra repository
    Log.Information($"Todo with ID {id} has been deleted.");
    }


    // Spesifikk kategori tilhørende oppgaver  
    public IEnumerable<Todo> GetTodosByCategory(int categoryId)
    {
        return _todoRepository.GetTodosByCategory(categoryId);
    }

    // Antall Todo-oppgaver per kategori
    public int CountTodosByCategory(int categoryId)
    {
        return _todoRepository.CountTodosByCategory(categoryId);
    }

    // Fullførte Todo-oppgaver inkludert kategori
    public IEnumerable<Todo> GetCompletedTodosWithCategory()
    {
        return _todoRepository.GetCompletedTodosWithCategory();
    }



}