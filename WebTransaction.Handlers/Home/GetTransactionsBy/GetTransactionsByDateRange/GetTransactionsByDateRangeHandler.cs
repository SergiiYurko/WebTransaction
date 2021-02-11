using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebTransaction.DataAccess.Interfaces;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByDateRange
{
    public class GetTransactionsByDateRangeHandler : IRequestHandler<GetTransactionsByDateRangeModelRequest, List<GetTransactionsByModelResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionsByDateRangeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<GetTransactionsByModelResponse>> Handle(GetTransactionsByDateRangeModelRequest request, CancellationToken cancellationToken)
        {
            var transactionList =
                (await _unitOfWork.TransactionRepository.GetAsync(p => p.Date >= request.StartDate && p.Date <= request.EndDate))
                .ToList();

            return _mapper.Map<List<GetTransactionsByModelResponse>>(transactionList);
        }
    }
}