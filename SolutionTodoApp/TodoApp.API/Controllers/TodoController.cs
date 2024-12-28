using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Contracts;
using TodoApp.Domain.DTOs;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// recover all the Todo
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        /// <summary>
        /// recover a Todo by Id
        /// </summary>
        /// <param name="id">Contains the id of the Todo to be retrieved</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        /// <summary>
        /// Get the tasks that are pending approval
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetPendingApproval")]
        public async Task<IActionResult> GetPendingApprovalAsync()
        {
            var todos = await _todoService.GetPendingApprovalAsync();
            return Ok(todos);
        }

        /// <summary>
        /// create Todo
        /// </summary>
        /// <param name="todo">object with the necessary parameters to be able to create Todo</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTodoAsync([FromBody] AddTodoDTO todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTodo = await _todoService.AddAsync(todo);
            return Ok(createdTodo);
        }

        /// <summary>
        /// update Todo
        /// </summary>
        /// <param name="idTodo">Contains the id of the Todo to be updated</param>
        /// <param name="todo">Contains updated information on the Todo</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{idTodo}")]
        public async Task<IActionResult> UpdateTodoAsync(int idTodo, [FromBody] UpdateTodoDTO todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTodo = await _todoService.UpdateTodoAsync(idTodo, todo);
            if (updatedTodo == null)
            {
                return NotFound();
            }

            return Ok(updatedTodo); 
        }

        /// <summary>
        /// changes the state of a Todo
        /// </summary>
        /// <param name="idTodo">Contains the id of the Todo to be updated</param>
        /// <param name="todo">Contains the status of the Todo to be updated</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("ChangeTodoStatus/{idTodo}")]
        public async Task<IActionResult> ChangeTodoStatusAsync(int idTodo, [FromBody] ChangeTodoStatusDTO todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTodoStatus = await _todoService.ChangeTodoStatusAsync(idTodo, todo);
            if (updatedTodoStatus == null)
            {
                return NotFound();
            }

            return Ok(updatedTodoStatus);
        }

        /// <summary>
        /// Updates the status and Pending Approval field for the selected Todos
        /// </summary>
        /// <param name="idTodoList">Contains a list with the ids corresponding to the Todo to be updated</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("UpdatePendingApproval")]
        public async Task<IActionResult> UpdatePendingApprovalAsync([FromBody] List<int> idTodoList)
        {
            if (idTodoList == null || !idTodoList.Any())
            {
                return BadRequest("The ID list cannot be empty.");
            }

            await _todoService.UpdatePendingApprovalAsync(idTodoList);
            return Ok();
        }

        /// <summary>
        /// Delete Todo
        /// </summary>
        /// <param name="idTodo">Contains the id of the Todo to be deleted</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{idTodo}")]
        public async Task<IActionResult> DeleteAsync(int idTodo)
        {
            var result = await _todoService.DeleteAsync(idTodo);
            if (result)
            {
                return NoContent(); 
            }
            return NotFound(); 
        }


    }
}
