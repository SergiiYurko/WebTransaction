using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTransaction.DataAccess.Interfaces;

namespace WebTransaction.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

    }
}