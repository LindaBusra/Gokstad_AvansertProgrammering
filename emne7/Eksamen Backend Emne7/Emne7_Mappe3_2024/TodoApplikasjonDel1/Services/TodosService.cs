using TodoApplikasjon.Models;
using Serilog;

//Her vi refaktorerte koden for å bruke Dependency Injection ved å flytte logikken fra TodosController til en egen tjeneste (TodosService)
public class TodosService : ITodosService
{

    public static List<Todo> todos = new List<Todo>     //Initierer en liste av Todo-objekter
        {
            new Todo {Id=1, Title="Todo1", Description="Create a home page", IsCompleted=false},
            new Todo {Id=2, Title="Todo2", Description="Create about us page", IsCompleted=false}
        };

    public IEnumerable<Todo> GetTodos() => todos;               //Returnerer alle Todo objekter

    public Todo? GetTodoById(int id) => todos.FirstOrDefault(b => b.Id == id);  //Finner en Todo med ID

    public void AddTodo(Todo todo)              //Legger en ny todo
    {
        todo.Id = todos.Max(b => b.Id) + 1;      //genererer ny id basert på max id fra todos
        todos.Add(todo);                        //Legger til ny Todo i min liste
        Log.Information($"Todo {todo.Title} added ");
    }

    public void UpdateTodo(int id, Todo updateTodo)
    {
        var todo = GetTodoById(id);                 //Finner Todo by using ID
        if (todo == null) return;                    //Avslutter hvis Todo ikke finnes

        todo.Title = updateTodo.Title;
        todo.Description = updateTodo.Description;
        todo.IsCompleted = updateTodo.IsCompleted;
        Log.Information($"The todo {todo.Title} is updated ");
    }

    public void DeleteTodo(int id)
    {
        var todo = GetTodoById(id);                 //Finner Todo by using ID
        if (todo != null) todos.Remove(todo);        //Fjerner Todo hvis den finnes
    }

}