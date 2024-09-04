using Application.Models.Response;

namespace Application.Interfaces;

public interface IUsersService
{
    Task<AppUserResponse> CreateUser(string username);
    Task<AppUserResponse> GetUserByUsernameAsync(string username);
}