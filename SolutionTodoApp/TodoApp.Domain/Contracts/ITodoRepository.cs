using TodoApp.Domain.Models;

namespace TodoApp.Domain.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<IEnumerable<Todo>> GetTodoPendingApprovalAsync();
        Task<Todo> AddTodoAsync(Todo todo);
        Task<Todo> UpdateTodoAsync(int idTodo, Todo todo);
        Task<bool> DeleteTodoAsync(int id);
        Task UpdateTodoPendingApprovalAsync(List<int> idTodoList);
    }
}
