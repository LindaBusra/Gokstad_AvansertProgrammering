using TodoApplikasjon.Models; 

// ITodosService definerer strukturen og tilgjengelige operasjoner som må implementeres.
public interface ITodosService
{
    IEnumerable<Todo> GetTodos();           //Henter alle todos
    Todo? GetTodoById(int id);              //henter en todo med id

    void AddTodo(Todo todo);                //legger en todo

    void UpdateTodo(int id, Todo todo);     //oppdater eksisterende todo

    void DeleteTodo(int id);                //sletter en todo basert på id


}