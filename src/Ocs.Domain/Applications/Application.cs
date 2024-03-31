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
        ApplicationOutline outline,
        DateTimeOffset submittedAt,
        DateTimeOffset createdAt,
        bool isSubmitted)
    {
        Id = id;
        AuthorId = authorId;
        ActivityType = activityType;
        Name = name;
        Description = description;
        Outline = outline;
        SubmittedAt = submittedAt;
        CreatedAt = createdAt;
        IsSubmitted = isSubmitted;
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
    
    /// <summary>
    /// Дата подачи
    /// </summary>
    public DateTimeOffset SubmittedAt { get; private set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; private set; }

    /// <summary>
    /// Подана ли заявка
    /// </summary>
    public bool IsSubmitted { get; private set; }
    
    /// <summary>
    /// Метод для изменения типа активности в заявке.
    /// </summary>
    public void ChangeActivityType(ActivityType activityType)
    {
        ActivityType = activityType;
    }

    /// <summary>
    /// Метод для изменения имени в заявке.
    /// </summary>
    public void ChangeName(ApplicationName name)
    {
        Name = name;
    }

    /// <summary>
    /// Метод для изменения описания в заявке.
    /// </summary>
    public void ChangeDescription(ApplicationDescription description)
    {
        Description = description;
    }

    /// <summary>
    /// Метод для изменения плана выступления в заявке.
    /// </summary>
    public void ChangeOutline(ApplicationOutline outline)
    {
        Outline = outline;
    }

    /// <summary>
    /// Метод для установки статуса подачи заявки на true и установки времени подачи.
    /// </summary>
    public void Submit()
    {
        IsSubmitted = true;
        SubmittedAt = DateTimeOffset.UtcNow;
    }
    
    /// <summary>
    /// Фабрика для создания заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="authorId">Id автора</param>
    /// <param name="activityType">Типа активности</param>
    /// <param name="name">Название</param>
    /// <param name="description">Краткое описание</param>
    /// <param name="outline">План выступления</param>
    /// <param name="submittedAt">Дата подачи</param>
    /// <param name="createdAt">Дата создания</param>
    /// <param name="isSubmitted">Подана ли заявка</param>
    /// <returns></returns>
    public static Application Create(
        Guid id,
        Guid authorId,  
        ActivityType activityType,
        ApplicationName name,
        ApplicationDescription description,
        ApplicationOutline outline,
        DateTimeOffset submittedAt = default,
        DateTimeOffset createdAt = default,
        bool isSubmitted = false)
    {
        return new Application(id, authorId, activityType, name, 
            description, outline, submittedAt, createdAt, isSubmitted);
    }
}