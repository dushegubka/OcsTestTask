using FluentValidation;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Users;

namespace Ocs.Api.Validators;

internal class ApplicationCreateViewValidator : AbstractValidator<ApplicationCreateView>
{
    internal ApplicationCreateViewValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidatorConstants.MaxNameLength);
        
        RuleFor(x => x.Description)
            .NotNull()
            .MaximumLength(ValidatorConstants.MaxDescriptionLength);
        RuleFor(x => x.Outline)
            .MaximumLength(ValidatorConstants.MaxOutlineLength);
        
    } }

internal class ApplicationEditViewValidator : AbstractValidator<ApplicationEditView>
{
    internal ApplicationEditViewValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidatorConstants.MaxNameLength);
        
        RuleFor(x => x.Description)
            .NotNull()
            .MaximumLength(ValidatorConstants.MaxDescriptionLength);
        RuleFor(x => x.Outline)
            .MaximumLength(ValidatorConstants.MaxOutlineLength);
        
    }
}