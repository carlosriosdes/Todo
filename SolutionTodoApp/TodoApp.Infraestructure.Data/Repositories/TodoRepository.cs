using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.Models;
using TodoApp.Infraestructure.Data.Context;

namespace TodoApp.Infraestructure.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppDBContext _context;

        public TodoRepository(TodoAppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync() 
        {
            return await _context.Todo.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id){
            return await _context.Todo.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetPendingApprovalAsync(){
            return await _context.Todo.Where(t => t.PendingApproval).ToListAsync();
        }
            
        public async Task AddAsync(Todo todo)
        {
            await _context.Todo.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todo.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo != null)
            {
                _context.Todo.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
