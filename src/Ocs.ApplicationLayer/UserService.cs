using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Views.Users;
using Ocs.Domain.Users;

namespace Ocs.ApplicationLayer;

/// <summary>
/// Сервис для работы с пользователями
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    /// <inheritdoc />
    public async Task<UserView> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        return UserView.Create(user);
    }

    /// <inheritdoc />
    public async Task<UserView> CreateAsync(UserCreateView newUser, CancellationToken cancellationToken = default)
    {
        var user = User.Create(
            Guid.NewGuid(),
            UserName.Create(newUser.Name));
        
        var result = await _userRepository.CreateAsync(user, cancellationToken);
        
        return UserView.Create(result);
    }
}