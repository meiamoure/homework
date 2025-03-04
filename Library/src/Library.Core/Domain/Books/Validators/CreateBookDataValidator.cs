using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Rules;

namespace Library.Core.Domain.Books.Validators;
public class CreateBookDataValidator : AbstractValidator<CreateBookData>
{
    public CreateBookDataValidator(ISerialNumberMustBeUniqueChecker serialNumberChecker)
    {
        RuleFor(x => x.SerialNumber)
           .NotEmpty()
           .WithMessage("Serial number is required.");
        RuleFor(x => x.SerialNumber)
            .CustomAsync(async (serialNumber, context, cancellationToken) =>
            {
                var checkResult = await new SerialNumberMustBeUniqueBusinessRule(serialNumber, serialNumberChecker).CheckAsync(cancellationToken);

                if (checkResult.IsSuccess) return;

                foreach (var error in checkResult.Errors)
                {
                    context.AddFailure(new ValidationFailure(nameof(CreateBookData.SerialNumber), error));
                }
            });

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Title can not be empty and longer than 100.");

        RuleFor(x => x.Description)
             .NotEmpty()
             .MaximumLength(2000)
             .WithMessage("Description can not be empty and longer than 2000 symbols.");
    }
}
