using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Transaction> TransactionRepository { get;}
        void SaveChanges();
    }
}