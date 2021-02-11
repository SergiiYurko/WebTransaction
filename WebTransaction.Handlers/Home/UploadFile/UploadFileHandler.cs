using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebTransaction.DataAccess.Interfaces;
using WebTransaction.Domain.Models;
using WebTransaction.Handlers.Helpers;
using WebTransaction.Handlers.Interfaces;

namespace WebTransaction.Handlers.Home.UploadFile
{
    public class UploadFileHandler: IRequestHandler<UploadFileRequestModel, UploadFileResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParser _parser;
        private readonly IMapper _mapper;

        public UploadFileHandler(IUnitOfWork unitOfWork, IParser parser, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _parser = parser;
            _mapper = mapper;
        }

        public async Task<UploadFileResponseModel> Handle(UploadFileRequestModel request, CancellationToken cancellationToken)
        {
            var fileInfoList = _parser.Parse(request.File); 
            _mapper.Map<List<Transaction>>(fileInfoList).ForEach(transaction => _unitOfWork.TransactionRepository.Create(transaction));
            _unitOfWork.SaveChanges();
            return new UploadFileResponseModel {Content = await request.File.GetBytes()};
        }
    }
}