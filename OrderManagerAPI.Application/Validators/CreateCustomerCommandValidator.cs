using FluentValidation;
using OrderManagerAPI.Application.Commands;

namespace OrderManagerAPI.Application.Validators;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Customer name is required.");
    }
}