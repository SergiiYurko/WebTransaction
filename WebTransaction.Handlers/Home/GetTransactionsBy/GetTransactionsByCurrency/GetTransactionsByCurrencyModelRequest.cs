using System.Collections.Generic;
using MediatR;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByCurrency
{
    public class GetTransactionsByCurrencyModelRequest:IRequest<List<GetTransactionsByModelResponse>>
    {
        public string Currency { get; set; }
    }
}