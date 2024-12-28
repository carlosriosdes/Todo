using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.DTOs;
using TodoApp.Infraestructure.Data.Context;

namespace TodoApp.Infraestructure.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TodoAppDBContext _context;

        public LoginRepository(TodoAppDBContext context)
        {
            _context = context;
        }
        public async Task<UserResponseLoginDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.UserName == loginDTO.Username && u.Password == loginDTO.Password);

            if (user == null)
            {
                return null;
            }

            return new UserResponseLoginDTO
            {
                UserName = user.UserName,
                Role = user.Role
            };
        }
    }
}
