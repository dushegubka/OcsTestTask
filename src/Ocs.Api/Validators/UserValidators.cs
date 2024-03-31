using FluentValidation;
using Ocs.ApplicationLayer.Users;

namespace Ocs.Api.Validators;

internal class UserCreateViewValidator : AbstractValidator<UserCreateView>
{
    internal UserCreateViewValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}