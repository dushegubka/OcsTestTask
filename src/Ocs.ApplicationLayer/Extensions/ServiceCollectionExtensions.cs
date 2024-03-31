using Microsoft.Extensions.DependencyInjection;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Users;
using Ocs.Domain.Users;
using Ocs.Infrastructure.Users;

namespace Ocs.ApplicationLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IApplicationService, ApplicationService>();
    }
}