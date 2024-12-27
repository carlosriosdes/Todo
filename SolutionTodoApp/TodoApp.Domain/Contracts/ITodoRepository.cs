using TodoApp.Domain.Models;

namespace TodoApp.Domain.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<IEnumerable<Todo>> GetPendingApprovalAsync();
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}
