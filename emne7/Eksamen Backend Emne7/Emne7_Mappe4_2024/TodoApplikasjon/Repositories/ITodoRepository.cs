using TodoApplikasjon.Models;

namespace TodoApplikasjon.Repository
{
    public interface ITodoRepository
    {
        IQueryable<Todo> GetAllTodos();     // henter alle Todo objekter
        Todo GetTodoById(int id);           // henter alle Todo objekter basert på id
        void AddTodo(Todo todo);            // opprettter en ny todo object
        void UpdateTodo(Todo todo);         // oppdaterer en eksistende todo object
        void DeleteTodo(int id);            // sletter en todo object basert på id

        IQueryable<Todo> GetTodosByCategory(int categoryId);  // Den bringer alle todo oppgaver som tilhører en kategori
        IQueryable<Todo> GetCompletedTodosWithCategory();     // Den bringer fullførte todo oppgaver med sine kategorier
        int CountTodosByCategory(int categoryId);             // Den regner todo oppgaver i en bestemt kategori
    }
}