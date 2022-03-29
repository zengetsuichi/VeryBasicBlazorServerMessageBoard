using Blazor.Models;

namespace Blazor.Services;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
    public void AddAsync(User user);
}