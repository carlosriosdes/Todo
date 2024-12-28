using TodoApp.Application.Contracts;
using TodoApp.Domain.Contracts;
using TodoApp.Domain.DTOs;

namespace TodoApp.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<UserResponseLoginDTO> LoginAsync(LoginDTO loginDTO)
        {
            return await _loginRepository.LoginAsync(loginDTO);
        }
    }
}

