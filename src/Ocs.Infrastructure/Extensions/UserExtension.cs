using Ocs.Domain.Users;
using Ocs.Infrastructure.Users;

namespace Ocs.Infrastructure.Extensions;

public static class UserExtension
{
    public static UserEntity ToDatabaseEntity(this User user)
    {
        return new UserEntity
        {
            Id = user.Id,
            Name = user.Name.Value
        };
    }

    public static User ToDomainModel(this UserEntity user)
    {
        return User.Create(
            user.Id,
            UserName.Create(user.Name));
    }
}