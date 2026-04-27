using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi;

public sealed class UserContext : DbContext
{
    private string _dbPath { get; set; }

    public DbSet<User> Users { get; set; }

    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "DemoDB.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}
