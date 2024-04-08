using Microsoft.Extensions.DependencyInjection;
using Ocs.Domain.Applications;
using Ocs.Infrastructure.Applications;

namespace Ocs.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
    }
}