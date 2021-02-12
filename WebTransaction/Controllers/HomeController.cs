using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebTransaction.Handlers.Home.GetTransactionsBy;
using WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByCurrency;
using WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByDateRange;
using WebTransaction.Handlers.Home.GetTransactionsBy.GetTransactionsByStatus;
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

        [HttpPost("upload")]
        public async Task<ActionResult<UploadFileResponseModel>> UploadFile([FromForm] UploadFileRequestModel model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        [HttpGet("transactions/currency")]
        public async Task<ActionResult<List<GetTransactionsByModelResponse>>> GetTransactionsByCurrency([FromQuery]
            GetTransactionsByCurrencyModelRequest model)
        {
            return await _mediator.Send(model);
        }

        [HttpGet("transactions/dateRange")]
        public async Task<ActionResult<List<GetTransactionsByModelResponse>>> GetTransactionsByDateRange([FromQuery]
            GetTransactionsByDateRangeModelRequest model)
        {
            return await _mediator.Send(model);
        }

        [HttpGet("transactions/status")]
        public async Task<ActionResult<List<GetTransactionsByModelResponse>>> GetTransactionsByStatus(
            [FromQuery] GetTransactionsByStatusModelRequest model)
        {
            return await _mediator.Send(model);
        }
    }
}