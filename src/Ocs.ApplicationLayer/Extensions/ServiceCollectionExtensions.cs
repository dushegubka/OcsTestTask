using Microsoft.Extensions.DependencyInjection;
using Ocs.ApplicationLayer.Abstractions.Services;
namespace Ocs.ApplicationLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationService, ApplicationService>();
    }
}