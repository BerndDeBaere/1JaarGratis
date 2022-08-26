using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IBaseRepository<T, TId>
{
    Task<List<T>> Get(CancellationToken cancellationToken);
    Task<T?> GetById(TId id);
    Task<T> Insert(T model, CancellationToken cancellationToken);
    Task<T> Update(T model, CancellationToken cancellationToken);
    Task Delete(T model, CancellationToken cancellationToken);
}

public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class
{
    private readonly Context _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(Context context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public Task<List<T>> Get(CancellationToken cancellationToken) => _entities.ToListAsync(cancellationToken);

    public Task<T?> GetById(TId id) => _entities.FindAsync(id).AsTask();

    public async Task<T> Insert(T model, CancellationToken cancellationToken)
    {
        _entities.Add(model);
        await _context.SaveChangesAsync(cancellationToken);
        return model;
    }

    public async Task<T> Update(T model, CancellationToken cancellationToken)
    {
        _entities.Update(model);
        await _context.SaveChangesAsync(cancellationToken);
        return model;
    }

    public Task Delete(T model, CancellationToken cancellationToken)
    {
        _entities.Remove(model);
        _context.SaveChangesAsync(cancellationToken);
        return Task.CompletedTask;
    }
}