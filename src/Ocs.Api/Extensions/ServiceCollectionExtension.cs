using Ocs.Api.ExceptionHandlers;

namespace Ocs.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<SubmittedApplicationEditingExceptionHandler>();
        services.AddExceptionHandler<SubmittedApplicationDeletingExceptionHandler>();
    }
}