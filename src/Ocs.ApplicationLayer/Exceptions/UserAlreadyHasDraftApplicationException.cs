namespace Ocs.ApplicationLayer.Exceptions;

public class UserAlreadyHasDraftApplicationException : Exception
{
    public UserAlreadyHasDraftApplicationException(Guid userId, string message) : base(message)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; }
}