using Ocs.Domain.Applications;

namespace Ocs.ApplicationLayer.Users;

public interface IUserService
{
    Task<UserView> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<UserView> CreateAsync(UserCreateView newUser, CancellationToken cancellationToken = default);
}