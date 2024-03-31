using Ocs.Domain.Applications;

namespace Ocs.ApplicationLayer.Users;

public interface IUserService
{
    Task<UserView> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<UserView> CreateAsync(UserCreateView newUser, CancellationToken cancellationToken = default);
    
    Task<bool> SetDraftApplicationAsync(Guid userId, Application application, CancellationToken cancellationToken);
    
    Task<bool> SubmitApplicationAsync(Guid userId, CancellationToken cancellationToken = default);
}