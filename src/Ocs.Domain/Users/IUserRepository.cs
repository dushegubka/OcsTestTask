namespace Ocs.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<User?> CreateAsync(User name, CancellationToken cancellationToken = default);

    Task<bool> AssignDraftApplicationAsync(Guid userId, CancellationToken cancellationToken);
}