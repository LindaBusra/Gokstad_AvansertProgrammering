using TodoApplikasjon.Data;
using TodoApplikasjon.Models;
using Microsoft.EntityFrameworkCore;


namespace TodoApplikasjon.Repository
{

    public class TodoRepository : ITodoRepository       // konstruktur, setter opp konteksen
    {
        private readonly TodoAppDbContext _context;

        public TodoRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public void AddTodo(Todo todo)                  // legger til en ny todo in database
        {
            try{
            _context.Todos.Add(todo);
            _context.SaveChanges();
            int result = _context.SaveChanges();
            Console.WriteLine("Number of changes saved", result);
            } catch (Exception ex)
            {
              Console.WriteLine("Number of changes saved", ex.Message);
              throw;
            }
        }

        public void DeleteTodo(int id)                  // sletter todo basert på id
        {
            var todo = GetTodoById(id);
            if(todo !=null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();                 // lagrer endringene etter sletting
            }
        }

        public IQueryable<Todo> GetAllTodos()           // henter alle Todos inkludert deres kategorier
        {
           return _context.Todos
           .Include(b=>b.Category);                      // inkluderer kategoriinformasjonen i hvert Todo-objekt
           
        }

        public Todo GetTodoById(int id)                 // henter en todo basert på id
        {
           return _context.Todos
           .Include(b=>b.Category)                       // inkluderer kategoriinformasjonen i det hentede Todo-objektet
           .FirstOrDefault(b=>b.Id==id) ?? new Todo();   // Returnerer Todo eller en ny Todo hvis ikke funnet
           
        }


        public void UpdateTodo(Todo todo)               // oppdaterer en eksistende todo
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();                     // lagrer endrinegene i databsen
        }


         public IQueryable<Todo> GetTodosByCategory(int categoryId)
        {
            // henter alle todo oppgaver i en spesifikk kategori
            return _context.Todos
                .Include(t => t.Category)
                .Where(t => t.CategoryId == categoryId);
        }

        public IQueryable<Todo> GetCompletedTodosWithCategory()
        {
            // henter alle fullførte todo oppgaver med sine kategoriinformasjon
            return _context.Todos
                .Include(t => t.Category)
                .Where(t => t.IsCompleted);
        }

        public int CountTodosByCategory(int categoryId)
        {
            //teller og returnerer antall todo oppgaver i en spesifikk kategori
            return _context.Todos
                .Count(t => t.CategoryId == categoryId);
        }
    }
}