using System;
using WebTransaction.DataAccess.Interfaces;
using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<FileInfo> _fileInfoRepository;
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<FileInfo> FileInfoRepository => _fileInfoRepository ??= new Repository<FileInfo>(_dbContext);

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