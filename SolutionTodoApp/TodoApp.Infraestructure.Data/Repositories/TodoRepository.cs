using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Models;
using TodoApp.Infraestructure.Data.Context;

namespace TodoApp.Infraestructure.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppDBContext _context;

        public TodoRepository(TodoAppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _context.Todo.Include(t => t.TodoState).ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todo
                        .Include(t => t.TodoState)
                        .FirstOrDefaultAsync(t => t.IdTodo == id);
        }

        public async Task<IEnumerable<Todo>> GetTodoPendingApprovalAsync()
        {
            return await _context.Todo.Include(t => t.TodoState).Where(t => t.PendingApproval).ToListAsync();
        }

        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            await _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> UpdateTodoAsync(int idTodo, Todo todo)
        {
            var existingTodo = await _context.Todo.FindAsync(idTodo);

            if (existingTodo == null)
            {
                return null;
            }

            existingTodo.Title = todo.Title;
            _context.Todo.Update(existingTodo);
            await _context.SaveChangesAsync();

            return existingTodo;
        }

        public async Task<bool> DeleteTodoAsync(int idTodo)
        {
            var todo = await _context.Todo.FindAsync(idTodo);
            if (todo == null)
            {
                return false;
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateTodoPendingApprovalAsync(List<int> idTodoList)
        {
            var todos = await _context.Todo.Where(t => idTodoList.Contains(t.IdTodo)).ToListAsync();
            foreach (var todo in todos)
            {
                todo.PendingApproval = false;
                todo.IdTodoState = (int)TodoStatus.Done;
            }

            await _context.SaveChangesAsync();
        }

    }
}
