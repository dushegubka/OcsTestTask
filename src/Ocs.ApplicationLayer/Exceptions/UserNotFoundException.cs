namespace Ocs.ApplicationLayer.Exceptions;

/// <summary>
/// Исключение, вызываемое при отсутствии пользователя с заданным идентификатором
/// </summary>
public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id, string message) : base(message)
    {
        UserId = id;
    }
    
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; }
}