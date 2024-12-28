using TodoApp.Domain.DTOs;
using TodoApp.Domain.Models;

namespace TodoApp.Application.Mappers
{
    public static class TodoMapper
    {
        public static Todo AddTodoDTOtoModel(AddTodoDTO addTodoDTO)
        {
            return new Todo
            {
                Title = addTodoDTO.Title,
                PendingApproval = addTodoDTO.PendingApproval,
                IdTodoState = addTodoDTO.IdTodoState
            };
        }

        public static Todo UpdateTodoDTOtoModel(UpdateTodoDTO updateTodoDTO)
        {
            return new Todo
            {
                Title = updateTodoDTO.Title
            };
        }

        public static ResponseTodoDTO ResponseTodoModeltoDTO(Todo modelTodo)
        {
            return new ResponseTodoDTO
            {
                Title = modelTodo.Title,
                State = modelTodo.TodoState.Description,
                PendingApproval = modelTodo.PendingApproval ? "Yes" : "No"
            };
        }

        public static List<ResponseTodoDTO> ResponseTodoModelListToDTOList(IEnumerable<Todo> modelTodoList)
        {
            return modelTodoList
                .Select(ResponseTodoModeltoDTO)
                .ToList();
        }
    }
}
