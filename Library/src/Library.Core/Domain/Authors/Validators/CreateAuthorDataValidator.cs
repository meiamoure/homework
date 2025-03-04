using FluentValidation;
using Library.Core.Domain.Authors.Data;

namespace Library.Core.Domain.Authors.Validators;
public class CreateAuthorDataValidator : AbstractValidator<CreateAuthorData>
{
    public CreateAuthorDataValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("First name can not be empty and longer than 50.");

        RuleFor(x => x.LastName)
             .NotEmpty()
             .MaximumLength(50)
             .WithMessage("Last name can not be empty and longer than 50.");
    }
}

