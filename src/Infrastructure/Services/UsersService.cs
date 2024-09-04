using Application.Interfaces;
using Application.Models.Response;

namespace Infrastructure.Services;

public class UsersService : IUsersService
{
    public Task<AppUserResponse> CreateUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<AppUserResponse> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}
