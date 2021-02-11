using System;
using WebTransaction.DataAccess.Interfaces;
using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Transaction> _transactionRepository;
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Transaction> TransactionRepository => _transactionRepository??= new Repository<Transaction>(_dbContext);
       
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}