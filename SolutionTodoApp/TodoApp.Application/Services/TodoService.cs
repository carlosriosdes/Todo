using TodoApp.Application.Contracts;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.Models;

namespace TodoApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository) 
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetPendingApprovalAsync()
        {
            return await _todoRepository.GetPendingApprovalAsync();
        }

        public async Task AddAsync(Todo todo)
        {
            await _todoRepository.AddAsync(todo);
        }

        public async Task UpdateAsync(Todo todo)
        {
            await _todoRepository.UpdateAsync(todo);
        }

        public async Task DeleteAsync(int id)
        {
            await _todoRepository.DeleteAsync(id);
        }
    }
}
