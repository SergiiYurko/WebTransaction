using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebTransaction.DataAccess.Interfaces;

namespace WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByStatus
{
    public class GetTransactionsByStatusHandler: IRequestHandler<GetTransactionsByStatusModelRequest, List<GetTransactionsByModelResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTransactionsByStatusHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetTransactionsByModelResponse>> Handle(GetTransactionsByStatusModelRequest request, CancellationToken cancellationToken)
        {
            var transactionList =
                (await _unitOfWork.TransactionRepository.GetAllAsync()).Where(p =>
                    p.Status.ToString().ToUpper().Equals(request.Status.ToUpper()));

            return _mapper.Map<List<GetTransactionsByModelResponse>>(transactionList);
        }
    }
}