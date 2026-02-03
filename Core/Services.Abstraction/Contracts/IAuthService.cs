using Shared.DTOs.Employee;

namespace Core.Services.Abstraction
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
