using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IBaseRepository<T, TId>
{
    Task<List<T>> Get(CancellationToken cancellationToken);
    Task<T?> GetById(TId id, CancellationToken cancelationToken);
    Task<T> Insert(T model, CancellationToken cancelationToken);
    Task<T> Update(T model, CancellationToken cancelationToken);
    Task Delete(T model, CancellationToken cancelationToken);
}

public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class
{
    private readonly Context _context;
    private readonly DbSet<T> _entities;

    internal BaseRepository(Context context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public Task<List<T>> Get(CancellationToken cancellationToken) => _entities.ToListAsync(cancellationToken);

    public Task<T?> GetById(TId id, CancellationToken cancelationToken) => _entities.FindAsync(id, cancelationToken).AsTask();

    public async Task<T> Insert(T model, CancellationToken cancelationToken)
    {
        _entities.Add(model);
        await _context.SaveChangesAsync(cancelationToken);
        return model;
    }

    public async Task<T> Update(T model, CancellationToken cancelationToken)
    {
        _entities.Update(model);
        await _context.SaveChangesAsync(cancelationToken);
        return model;
    }

    public Task Delete(T model, CancellationToken cancelationToken)
    {
        _entities.Remove(model);
        _context.SaveChangesAsync(cancelationToken);
        return Task.CompletedTask;
    }
}