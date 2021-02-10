using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebTransaction.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        Task<TEntity> FindByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
