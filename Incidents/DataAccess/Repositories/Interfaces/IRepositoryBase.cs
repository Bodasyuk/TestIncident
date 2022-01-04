using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Incidents.DataAccess.Repositories.Interfaces;

public interface IRepositoryBase<T>
{
    void Create(T entity);
    Task CreateAsync(T entity);
    
    void Update(T entity);

    void Delete(T entity);

    public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
}