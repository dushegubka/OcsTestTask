using Ocs.ApplicationLayer.Applications;
using Ocs.Domain.Applications;
using Ocs.Domain.Users;

namespace Ocs.ApplicationLayer.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserView> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        return UserView.Create(user);
    }

    public async Task<UserView> CreateAsync(UserCreateView newUser, CancellationToken cancellationToken = default)
    {
        var user = User.Create(
            Guid.NewGuid(),
            UserName.Create(newUser.Name));
        
        var result = await _userRepository.CreateAsync(user, cancellationToken);
        
        return UserView.Create(result);
    }

    public async Task<bool> SetDraftApplicationAsync(Guid userId, Application application, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            return false;
        }

        await _userRepository.AssignDraftApplicationAsync(userId, cancellationToken);

        return true;
    }

    public async Task<bool> SubmitApplicationAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}