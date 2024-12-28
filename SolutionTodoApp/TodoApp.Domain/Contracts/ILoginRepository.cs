using TodoApp.Domain.DTOs;

namespace TodoApp.Domain.Contracts
{
    public interface ILoginRepository
    {
        Task<UserResponseLoginDTO> LoginAsync(LoginDTO loginDTO);
    }
}
