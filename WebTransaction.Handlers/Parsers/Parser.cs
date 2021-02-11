using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using WebTransaction.Handlers.DTO;
using WebTransaction.Handlers.Interfaces;

namespace WebTransaction.Handlers.Parsers
{
    public class Parser: IParser
    {
        private ILogger<Parser> _logger;

        public Parser(ILogger<Parser> logger)
        {
            _logger = logger;
        }

        public List<FileInfoDTO> Parse(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            try
            {
                return extension switch
                {
                    ".csv" => ParserCSV.Parse(file),
                    ".xml" => ParserXML.Parse(file),
                    _ => null
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}