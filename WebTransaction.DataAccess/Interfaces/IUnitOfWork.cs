using WebTransaction.Domain.Models;

namespace WebTransaction.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<FileInfo> FileInfoRepository { get;}
    }
}