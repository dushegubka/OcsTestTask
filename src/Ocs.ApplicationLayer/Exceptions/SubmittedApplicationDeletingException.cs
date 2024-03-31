namespace Ocs.ApplicationLayer.Exceptions;

/// <summary>
/// Исключение попытки удаления подтвержденной заявки
/// </summary>
public class SubmittedApplicationDeletingException : Exception
{
    public SubmittedApplicationDeletingException(Guid id, string message) : base(message)
    {
        ApplicationId = id;
    }
    
    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid ApplicationId { get; }
}