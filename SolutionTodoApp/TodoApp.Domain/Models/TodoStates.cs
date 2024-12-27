namespace TodoApp.Domain.Models
{
    public class TodoStates
    {
        public int IdTodoState { get; set; }
        public string Description { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
