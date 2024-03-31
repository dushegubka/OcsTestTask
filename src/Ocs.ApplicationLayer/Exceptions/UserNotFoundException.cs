namespace Ocs.ApplicationLayer.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id, string message) : base(message)
    {
        UserId = id;
    }
    
    public Guid UserId { get; }
}