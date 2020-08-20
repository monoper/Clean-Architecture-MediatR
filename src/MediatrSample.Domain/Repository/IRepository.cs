using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediatrSample.Domain.Repository
{
    public interface IRepository<T, TId>
    {
        Task<TId> Add(T entity);
        Task<T> Get(TId id);
        Task Update(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
    }
}
