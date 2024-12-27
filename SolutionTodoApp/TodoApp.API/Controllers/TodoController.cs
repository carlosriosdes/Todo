using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Contracts;
using TodoApp.Domain.Models;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpGet("GetPendingApprovalAsync")]
        public async Task<IActionResult> GetPendingApprovalAsync()
        {
            var todos = await _todoService.GetPendingApprovalAsync();
            return Ok(todos);
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] Todo todo)
        {
            await _todoService.AddAsync(todo);
            return Ok();
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] Todo todo)
        {
            await _todoService.UpdateAsync(todo);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _todoService.DeleteAsync(id);
            return Ok();
        }
    }
}
