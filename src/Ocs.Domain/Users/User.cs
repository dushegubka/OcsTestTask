using Ocs.Domain.Applications;

namespace Ocs.Domain.Users;

/// <summary>
/// Класс пользователя
/// </summary>
public class User
{
    private User(Guid id, UserName name)
    {
        Id = id;
        Name = name;
    }
    
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public UserName Name { get; }
    
    public static User Create(Guid id, UserName name)
    {
        
        return new User(id, name);
    }
}