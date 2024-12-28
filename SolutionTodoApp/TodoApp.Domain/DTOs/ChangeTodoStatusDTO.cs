using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain.DTOs
{
    public class ChangeTodoStatusDTO
    {
        [Required(ErrorMessage = "IdTodoState is required.")]
        public int IdTodoState { get; set; }
    }
}
