namespace TodoApp.Domain.Models
{
    public class Todo
    {
        public int IdTodo { get; set; }
        public string Title { get; set; }
        public bool PendingApproval { get; set; }
        public int IdTodoState { get; set; }
        public TodoStates TodoState { get; set; }
    }
}
