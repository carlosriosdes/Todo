using TodoApp.Domain.DTOs;
using TodoApp.Domain.Models;

namespace TodoApp.Application.Contracts
{
    public interface ITodoService
    {
        Task<IEnumerable<ResponseTodoDTO>> GetAllAsync();
        Task<ResponseTodoDTO> GetByIdAsync(int id);
        Task<IEnumerable<ResponseTodoDTO>> GetPendingApprovalAsync();
        Task<ResponseTodoDTO> AddAsync(AddTodoDTO todo);
        Task<ResponseTodoDTO> UpdateTodoAsync(int idTodo, UpdateTodoDTO todo);
        Task<bool> DeleteAsync(int id);
        Task<ResponseTodoDTO> ChangeTodoStatusAsync(int idTodo, ChangeTodoStatusDTO todo);
        Task UpdatePendingApprovalAsync(List<int> idTodoList);
    }
}
