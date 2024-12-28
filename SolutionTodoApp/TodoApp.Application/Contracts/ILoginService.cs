using TodoApp.Domain.DTOs;

namespace TodoApp.Application.Contracts
{
    public interface ILoginService
    {
        Task<UserResponseLoginDTO> LoginAsync(LoginDTO loginDTO);
    }
}
