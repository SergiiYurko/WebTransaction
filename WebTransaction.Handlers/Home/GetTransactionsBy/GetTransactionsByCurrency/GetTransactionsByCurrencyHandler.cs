using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebTransaction.DataAccess.Interfaces;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByCurrency
{
    public class GetTransactionsByCurrencyHandler: IRequestHandler<GetTransactionsByCurrencyModelRequest, List<GetTransactionsByModelResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionsByCurrencyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetTransactionsByModelResponse>> Handle(GetTransactionsByCurrencyModelRequest request, CancellationToken cancellationToken)
        {
            var transactionList =
                (await _unitOfWork.TransactionRepository.GetAsync(p => p.CurrencyCode.Equals(request.Currency.ToUpper())))
                .ToList();

            return _mapper.Map<List<GetTransactionsByModelResponse>>(transactionList);
        }
    }
}