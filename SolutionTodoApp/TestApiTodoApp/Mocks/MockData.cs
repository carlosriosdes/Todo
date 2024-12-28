using TodoApp.Domain.DTOs;
using TodoApp.Domain.Models;

namespace TestApiTodoApp.Mocks
{
    public static class MockData
    {
        public static TodoStates GetTodoStates()
        {
            return new TodoStates
            {
                Description = "Todo",
                IdTodoState = 1
            };
        }

        public static Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            var todoState = GetTodoStates();
            var mockData = new List<Todo>
            {
                new Todo { Title = "Todo1", TodoState = todoState, PendingApproval = true },
                new Todo { Title = "Todo2", TodoState = todoState, PendingApproval = false }
            };

            return Task.FromResult((IEnumerable<Todo>)mockData);
        }

        public static Task<Todo> GetTodoByIdAsync()
        {
            var todoState = GetTodoStates();
            return Task.FromResult(new Todo
            {
                Title = "Todo1",
                TodoState = todoState,
                PendingApproval = true
            });
        }
    }
}
