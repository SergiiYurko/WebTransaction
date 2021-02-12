using FluentValidation;

namespace WebTransaction.Handlers.Home.UploadFile
{
    public class UploadFileValidator: AbstractValidator<UploadFileRequestModel>
    {
        public UploadFileValidator()
        {
            RuleFor(p => p.File).NotNull().WithMessage("File is null");
            When(x => x.File != null, () =>
            {
                RuleFor(p => p.File).Must(s => s.Length > 0).WithMessage("File is empty");
                RuleFor(p => p.File).Must(l => l.Length <= 1048576).WithMessage("File size is max 1 MB");
                RuleFor(p => p.File).Must(s => s.FileName.Contains(".csv") || s.FileName.Contains(".xml"))
                    .WithMessage("Unknown format");
            });
        }
    }
}