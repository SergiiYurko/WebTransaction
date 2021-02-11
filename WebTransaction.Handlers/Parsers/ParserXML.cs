using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using WebTransaction.Domain.Models;
using WebTransaction.Handlers.DTO;

namespace WebTransaction.Handlers.Parsers
{
    public class ParserXML
    {
        public static List<FileInfoDTO> Parse(IFormFile file)
        {
            var fileInfos = new List<FileInfoDTO>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var doc = XDocument.Load(reader);

                foreach (var transaction in doc.Element("Transactions").Elements("Transaction"))
                {
                    var fileInfo = new FileInfoDTO
                    {
                        TransactionId = transaction.Attribute("id").Value,
                        Date = DateTime.ParseExact(transaction.Element("TransactionDate").Value, "yyyy-MM-ddTHH:mm:ss",
                            null),
                        Amount = decimal.Parse(transaction.Element("PaymentDetails").Element("Amount").Value),
                        CurrencyCode = transaction.Element("PaymentDetails").Element("CurrencyCode").Value
                    };

                    fileInfo.Status = transaction.Element("Status").Value switch
                    {
                        "Approved" => StatusTransaction.Approved,
                        "Rejected" => StatusTransaction.Rejected,
                        "Done" => StatusTransaction.Done,
                        _ => fileInfo.Status
                    };

                    fileInfos.Add(fileInfo);
                }
            }

            return fileInfos;
        }
    }
}