using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Repositories;

public class SQLiteUserRepository(UserContext context) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<User>> GetAllAsync()
        => await context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user != null)
            return user;

        return null;
    }
}
