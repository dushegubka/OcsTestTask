namespace Ocs.ApplicationLayer.Exceptions;

/// <summary>
/// Исключение попытки редактирования подтвержденной заявки
/// </summary>
public class SubmittedApplicationEditingException : Exception
{
    public SubmittedApplicationEditingException(Guid id, string message) : base(message)
    {
        ApplicationId = id;
    }

    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid ApplicationId { get; }
}