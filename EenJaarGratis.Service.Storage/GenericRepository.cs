using System.Linq.Expressions;
using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IBaseRepository<T>
{
    Task<List<T>> Get(CancellationToken cancellationToken);
    Task<T> GetById(int id,params Expression<Func<T, object>>[] includes);
    Task<T> Insert(T model, CancellationToken cancellationToken);
    Task<T> Update(T model, CancellationToken cancellationToken);
    Task Delete(T model, CancellationToken cancellationToken);
}

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    internal readonly Context _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(Context context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public Task<List<T>> Get(CancellationToken cancellationToken) => _entities.ToListAsync(cancellationToken);

    public Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _entities.AsQueryable();

        includes?.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return query.SingleOrDefaultAsync(x => x.Id == id)!;
    }

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