using Ocs.Domain.Applications;

namespace Ocs.ApplicationLayer.Users;

public interface IUserService
{
    /// <summary>
    /// Метод для получения пользователя по Id
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>ДТО пользователя</returns>
    Task<UserView> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для создания пользователя
    /// </summary>
    /// <param name="newUser">Объект пользователя</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>ДТО созданного пользователя</returns>
    Task<UserView> CreateAsync(UserCreateView newUser, CancellationToken cancellationToken = default);
}