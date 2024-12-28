using TodoApp.Application.Contracts;
using TodoApp.Application.Mappers;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.DTOs;
using TodoApp.Domain.Enums;
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

        public async Task<IEnumerable<ResponseTodoDTO>> GetAllAsync()
        {
            var responseListTodo = await _todoRepository.GetAllTodosAsync();
            return TodoMapper.ResponseTodoModelListToDTOList(responseListTodo);
        }

        public async Task<ResponseTodoDTO> GetByIdAsync(int id)
        {
            var responseTodo = await _todoRepository.GetTodoByIdAsync(id);
            return TodoMapper.ResponseTodoModeltoDTO(responseTodo);
        }

        public async Task<IEnumerable<ResponseTodoDTO>> GetPendingApprovalAsync()
        {
            var responseListTodo = await _todoRepository.GetTodoPendingApprovalAsync();
            return TodoMapper.ResponseTodoModelListToDTOList(responseListTodo);
        }

        public async Task<ResponseTodoDTO> AddAsync(AddTodoDTO todo)
        {
            var responseTodo = await _todoRepository.AddTodoAsync(TodoMapper.AddTodoDTOtoModel(todo));
            return TodoMapper.ResponseTodoModeltoDTO(responseTodo);
        }

        public async Task<ResponseTodoDTO> UpdateTodoAsync(int idTodo, UpdateTodoDTO todo)
        {
            var responseTodo = await _todoRepository.UpdateTodoAsync(idTodo, TodoMapper.UpdateTodoDTOtoModel(todo));
            return TodoMapper.ResponseTodoModeltoDTO(responseTodo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todoExists = await _todoRepository.GetTodoByIdAsync(id);
            if (todoExists == null)
            {
                return false;  
            }

            await _todoRepository.DeleteTodoAsync(id);
            return true;  
        }

        public async Task<ResponseTodoDTO> ChangeTodoStatusAsync(int idTodo, ChangeTodoStatusDTO todo)
        {
            Todo todoResult = await _todoRepository.GetTodoByIdAsync(idTodo);
            if (todo.IdTodoState == (int)TodoStatus.Done)
            {
                todoResult.PendingApproval = true;
            }
            else
            {
                todoResult.IdTodoState = todo.IdTodoState;
            }

            var responseTodo = await _todoRepository.UpdateTodoAsync(idTodo, todoResult);
            return TodoMapper.ResponseTodoModeltoDTO(responseTodo);
        }

        public async Task UpdatePendingApprovalAsync(List<int> idTodoList)
        {
            await _todoRepository.UpdateTodoPendingApprovalAsync(idTodoList);
        }

    }
}
