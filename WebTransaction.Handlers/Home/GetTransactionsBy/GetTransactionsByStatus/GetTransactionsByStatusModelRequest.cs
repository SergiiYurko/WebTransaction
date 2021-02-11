using System.Collections.Generic;
using MediatR;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByStatus
{
    public class GetTransactionsByStatusModelRequest: IRequest<List<GetTransactionsByModelResponse>>
    {
        public string Status { get; set; }
    }
}