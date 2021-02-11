using MediatR;
using Microsoft.AspNetCore.Http;

namespace WebTransaction.Handlers.Home.UploadFile
{
    public class UploadFileRequestModel: IRequest<UploadFileResponseModel>
    {
        public IFormFile File { get; set; }
    }
}