﻿using Ocs.ApplicationLayer.Applications;
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
}