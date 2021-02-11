using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace WebTransaction.Handlers.Home.UploadFile
{
    public class UploadFileValidator: AbstractValidator<IFormFile>
    {
        public UploadFileValidator()
        {
            RuleFor(p => p).NotNull().WithMessage("File is null");
            RuleFor(p => p.Length).Must(s => s > 0).WithMessage("File is empty");
            RuleFor(p => p.Length).Must(l => l <= 1048576).WithMessage("File size is max 1 MB");
            RuleFor(p => p.FileName).Must(s => s.Contains(".csv") || s.Contains(".xml"))
                .WithMessage("Unknown format");
        }
    }
}