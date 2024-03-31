namespace Ocs.ApplicationLayer.Exceptions;

public class SubmittedApplicationDeletingException : Exception
{
    public SubmittedApplicationDeletingException(Guid id, string message) : base(message)
    {
        ApplicationId = id;
    }
    
    public Guid ApplicationId { get; }
}