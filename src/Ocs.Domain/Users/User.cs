using Ocs.Domain.Applications;

namespace Ocs.Domain.Users;

public class User
{
    private User(Guid id, UserName name)
    {
        Id = id;
        Name = name;
    }
    
    public Guid Id { get; }
    
    public UserName Name { get; }
    
    public static User Create(Guid id, UserName name)
    {
        
        return new User(id, name);
    }
}