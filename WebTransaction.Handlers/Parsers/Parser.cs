using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using WebTransaction.Handlers.DTO;
using WebTransaction.Handlers.Interfaces;

namespace WebTransaction.Handlers.Parsers
{
    public class Parser: IParser
    {
        public List<FileInfoDTO> Parse(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            return extension switch
            {
                ".csv" => ParserCSV.Parse(file),
                ".xml" => ParserXML.Parse(file),
                _ => null
            };
        }
    }
}