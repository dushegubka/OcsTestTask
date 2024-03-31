using Microsoft.Extensions.DependencyInjection;
using Ocs.Domain.Applications;
using Ocs.Domain.Users;
using Ocs.Infrastructure.Applications;
using Ocs.Infrastructure.Users;

namespace Ocs.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
    }
}