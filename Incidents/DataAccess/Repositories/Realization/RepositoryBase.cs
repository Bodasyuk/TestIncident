using System.Linq.Expressions;
using Incidents.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Incidents.DataAccess.Repositories.Realization;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected IncidentsDBContext _dbContext { get; set; }

    public RepositoryBase(IncidentsDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
    
    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = GetQuery(predicate, include);
        return (await query.FirstOrDefaultAsync())!;
    }
    public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = GetQuery(predicate, include);
        return await query.FirstAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        return await GetQuery(predicate, include).ToListAsync();
    }
    
    private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsNoTracking();
        if (include != null)
        {
            query = include(query);
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return query;
    }
}