using UserApi.DTOs;
using UserApi.Models;
using UserApi.Repositories;

namespace UserApi.Services;

public sealed class UserManager(IUserRepository repository)
{
    public async Task<List<User>> GetAllAsync() 
        => await repository.GetAllAsync();

    public async Task<User?> GetByIdAsync(int id) 
        => await repository.GetByIdAsync(id);

    public async Task CreateAsync(UserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        await repository.AddAsync(user);
    }

    public async Task DeleteAsync(int id) 
        => await repository.DeleteAsync(id);
}
