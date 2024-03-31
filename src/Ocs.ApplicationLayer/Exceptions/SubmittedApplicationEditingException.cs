namespace Ocs.ApplicationLayer.Exceptions;

public class SubmittedApplicationEditingException : Exception
{
    public SubmittedApplicationEditingException(Guid id, string message) : base(message)
    {
        ApplicationId = id;
    }

    public Guid ApplicationId { get; }
}