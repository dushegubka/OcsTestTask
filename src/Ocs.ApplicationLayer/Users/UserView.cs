using Ocs.ApplicationLayer.Applications;
using Ocs.Domain.Users;

namespace Ocs.ApplicationLayer.Users;

public class UserView
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public static UserView Create(User user)
    {
        return new UserView
        {
            Id = user.Id,
            Name = user.Name.Value
        };
    }
}