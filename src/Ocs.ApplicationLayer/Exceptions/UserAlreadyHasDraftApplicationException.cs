namespace Ocs.ApplicationLayer.Exceptions;

/// <summary>
/// Исключение, выбрасываемое при попытке создать заявку пользователем, который уже имеет заявку
/// </summary>
public class UserAlreadyHasDraftApplicationException : Exception
{
    public UserAlreadyHasDraftApplicationException(Guid userId, string message) : base(message)
    {
        UserId = userId;
    }
    
    /// <summary>
    /// Id автора
    /// </summary>
    public Guid UserId { get; }
}