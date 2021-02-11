using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using WebTransaction.Handlers.DTO;

namespace WebTransaction.Handlers.Interfaces
{
    public interface IParser
    {
        List<FileInfoDTO> Parse(IFormFile file);
    }
}