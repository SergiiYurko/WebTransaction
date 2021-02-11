using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using WebTransaction.Domain.Models;
using WebTransaction.Handlers.DTO;

namespace WebTransaction.Handlers.Parsers
{
    public class ParserCSV
    {
        public static List<FileInfoDTO> Parse(IFormFile file)
        {
            var fileInfos = new List<FileInfoDTO>();
            using (var reader = new TextFieldParser(file.OpenReadStream()))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");
                while (!reader.EndOfData)
                {
                    var fields = reader.ReadFields();
                    var fileInfo = new FileInfoDTO
                    {
                        TransactionId = fields[0],
                        Amount = decimal.Parse(fields[1]),
                        CurrencyCode = fields[2],
                        Date = DateTime.ParseExact(fields[3], "dd/MM/yyyy HH:mm:ss", null)
                    };

                    fileInfo.Status = fields[4] switch
                    {
                        "Approved" => StatusTransaction.Approved,
                        "Failed" => StatusTransaction.Failed,
                        "Finished" => StatusTransaction.Finished,
                        _ => fileInfo.Status
                    };

                    fileInfos.Add(fileInfo);
                }
            }

            return fileInfos;
        }
    }
}