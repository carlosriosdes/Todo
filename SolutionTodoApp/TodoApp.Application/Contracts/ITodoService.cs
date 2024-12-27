using TodoApp.Domain.Models;

namespace TodoApp.Application.Contracts
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<IEnumerable<Todo>> GetPendingApprovalAsync();
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}
