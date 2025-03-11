using TodoApplikasjon.Models;

public interface ITodosService
{
    IEnumerable<Todo> GetTodos();           //Henter alle todos
    Todo? GetTodoById(int id);              //henter en todo med id

    void AddTodo(Todo todo);                //legger en todo

    void UpdateTodo(int id, Todo todo);     //oppdater eksisterende todo

    void DeleteTodo(int id);                //sletter en todo basert på id

    IEnumerable<Todo> GetTodosByCategory(int categoryId);   // Henter alle todos for en spesifikk kategori
    int CountTodosByCategory(int categoryId);               // Teller antall todos i en kategori
    IEnumerable<Todo> GetCompletedTodosWithCategory();      // Henter alle fullførte todos med kategoriinformasjon

}