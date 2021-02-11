using System;
using WebTransaction.Domain.Models;

namespace WebTransaction.Handlers.DTO
{
    public class FileInfoDTO
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime Date { get; set; }
        public StatusTransaction Status { get; set; }
    }
}