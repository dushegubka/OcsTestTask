namespace Ocs.ApplicationLayer.Exceptions;

public class ApplicationNotFoundException : Exception
{
    public ApplicationNotFoundException(Guid id, string message) : base(message)
    {
        Id = id;
    }
    
    public Guid Id { get; init; }
}