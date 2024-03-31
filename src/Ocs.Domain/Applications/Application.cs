using Ocs.Domain.Enums;
using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

/// <summary>
/// Заявка на активность
/// </summary>
public class Application
{

    private Application(Guid id,
        Guid authorId,
        ActivityType activityType,
        ApplicationName name,
        ApplicationDescription description,
        ApplicationOutline outline)
    {
        Id = id;
        AuthorId = authorId;
        ActivityType = activityType;
        Name = name;
        Description = description;
        Outline = outline;
    }
    
    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Id автора
    /// </summary>
    public Guid AuthorId { get; }
    
    /// <summary>
    /// Тип активности
    /// </summary>
    public ActivityType ActivityType { get; private set; }
    
    /// <summary>
    /// Заголовок заявки
    /// </summary>
    public ApplicationName Name { get; private set; }

    /// <summary>
    /// Краткое описание для сайта
    /// </summary>
    public ApplicationDescription Description { get; private set; }
    
    /// <summary>
    /// План выступления
    /// </summary>
    public ApplicationOutline Outline { get; private set; }
    
    public void ChangeActivityType(ActivityType activityType)
    {
        ActivityType = activityType;
    }
    
    public void ChangeName(ApplicationName name)
    {
        Name = name;
    }
    
    public void ChangeDescription(ApplicationDescription description)
    {
        Description = description;
    }
    
    public void ChangeOutline(ApplicationOutline outline)
    {
        Outline = outline;
    }
    
    public void Submit()
    {
        IsSubmitted = true;
        SubmittedAt = DateTimeOffset.UtcNow;
    }
    
    public static Application Create(
        Guid id,
        Guid authorId,  
        ActivityType activityType,
        ApplicationName name,
        ApplicationDescription description,
        ApplicationOutline outline)
        ApplicationOutline outline,
    {
        return new Application(id, authorId, activityType, title, description, outline);
    }
}