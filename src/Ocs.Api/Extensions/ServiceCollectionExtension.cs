using FluentValidation;
using Ocs.Api.ExceptionHandlers;
using Ocs.Api.Validators;
using Ocs.ApplicationLayer.Views.Applications;

namespace Ocs.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<SubmittedApplicationEditingExceptionHandler>();
        services.AddExceptionHandler<SubmittedApplicationDeletingExceptionHandler>();
        services.AddExceptionHandler<UserNotFoundExceptionHandler>();
        services.AddExceptionHandler<UserAlreadyHasDraftApplicationExceptionHandler>();
        services.AddExceptionHandler<ApplicationNotFoundExceptionHandler>();
        services.AddExceptionHandler<IncorrectDateTimeFormatExceptionHandler>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<ApplicationCreateView>, ApplicationCreateViewValidator>();
        services.AddScoped<IValidator<ApplicationEditView>, ApplicationEditViewValidator>();
    }
}