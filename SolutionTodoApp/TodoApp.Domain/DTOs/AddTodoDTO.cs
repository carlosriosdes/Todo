﻿using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain.DTOs
{
    public class AddTodoDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public string Title { get; set; }
        public bool PendingApproval { get; } = false;
        public int IdTodoState { get; } = 1;
    }
}