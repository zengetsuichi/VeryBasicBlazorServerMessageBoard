using Blazor.Models;

namespace Blazor.Services.Impls;

public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return find;
    }

    public void AddAsync(User user)
    {
        users.Add(user);
        
    }

    private List<User> users = new()
    {
        new User("Piotr", "qwerty", "Admin", 5, 1998),
              
    };
}