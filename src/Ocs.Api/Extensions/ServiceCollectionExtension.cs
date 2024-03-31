using FluentValidation;
using Ocs.Api.ExceptionHandlers;
using Ocs.Api.Validators;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Users;

namespace Ocs.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<SubmittedApplicationEditingExceptionHandler>();
        services.AddExceptionHandler<SubmittedApplicationDeletingExceptionHandler>();
        services.AddExceptionHandler<UserNotFoundExceptionHandler>();
        services.AddExceptionHandler<UserAlreadyHasDraftApplicationExceptionHandler>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<ApplicationCreateView>, ApplicationCreateViewValidator>();
        services.AddScoped<IValidator<ApplicationEditView>, ApplicationEditViewValidator>();
        
        services.AddScoped<IValidator<UserCreateView>, UserCreateViewValidator>();
    }
}