using System;
using System.ComponentModel.DataAnnotations;

namespace WebTransaction.Domain.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        [DataType(DataType.Currency)]
        public string CurrencyCode { get; set; }
        public DateTime Date { get; set; }
        public StatusTransaction Status { get; set; }
    }
}