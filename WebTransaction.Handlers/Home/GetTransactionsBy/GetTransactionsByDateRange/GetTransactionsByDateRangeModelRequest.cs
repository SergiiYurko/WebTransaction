using System;
using System.Collections.Generic;
using MediatR;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByDateRange
{
    public class GetTransactionsByDateRangeModelRequest: IRequest<List<GetTransactionsByModelResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}