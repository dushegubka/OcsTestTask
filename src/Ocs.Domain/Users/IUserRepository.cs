namespace Ocs.Domain.Users;

/// <summary>
/// Репозиторий для работы с user
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Метод получения пользователя по идентификатору
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Объект пользователя</returns>
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод создания пользователя
    /// </summary>
    /// <param name="newUser">Объект пользователя</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Созданный пользователь</returns>
    Task<User?> CreateAsync(User newUser, CancellationToken cancellationToken = default);
}