using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
}