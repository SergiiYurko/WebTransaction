using System.Globalization;
using AutoMapper;
using WebTransaction.Domain.Models;
using WebTransaction.Handlers.DTO;
using WebTransaction.Handlers.Home.GetTransactionsBy;

namespace WebTransaction.Handlers.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<FileInfoDTO, Transaction>();
            CreateMap<Transaction, GetTransactionsByModelResponse>()
                .ForMember(m => m.Id, t => t.MapFrom(s => s.TransactionId))
                .ForMember(m => m.Payment,
                    t => t.MapFrom(s => s.Amount.ToString(CultureInfo.InvariantCulture) + s.CurrencyCode))
                .ForMember(m => m.Status, t => t.MapFrom(s =>
                    s.Status == StatusTransaction.Approved ? "A" :
                    s.Status == StatusTransaction.Failed || s.Status == StatusTransaction.Rejected ? "R" :
                    s.Status == StatusTransaction.Finished || s.Status == StatusTransaction.Done ? "D" : null));
        }
    }
}