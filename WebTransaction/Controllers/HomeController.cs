using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTransaction.Handlers.Home.UploadFile;

namespace WebTransaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UploadFileResponseModel>> UploadFile(IFormFile model)
        {
            return await _mediator.Send(new UploadFileRequestModel{File = model});
        }
    }
}