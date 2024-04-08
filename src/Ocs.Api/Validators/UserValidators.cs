using FluentValidation;
using Ocs.ApplicationLayer.Views.Users;

namespace Ocs.Api.Validators;

public class UserCreateViewValidator : AbstractValidator<UserCreateView>
{
    public UserCreateViewValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}