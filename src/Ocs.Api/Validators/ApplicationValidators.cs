using FluentValidation;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Users;

namespace Ocs.Api.Validators;

public class ApplicationCreateViewValidator : AbstractValidator<ApplicationCreateView>
{
    public ApplicationCreateViewValidator()
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

public class ApplicationEditViewValidator : AbstractValidator<ApplicationEditView>
{
    public ApplicationEditViewValidator()
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