using Ocs.Domain.Applications;
using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Views.Applications;

/// <summary>
/// ДТО заявки
/// </summary>
public class ApplicationView
{
    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Id автора
    /// </summary>
    public Guid Author { get; init; }
    
    /// <summary>
    /// Тип активности
    /// </summary>
    public ActivityType Activity { get; init; }

    /// <summary>
    /// Название заявки
    /// </summary>
    public string? Name { get; init; }
    
    /// <summary>
    /// Краткое описание
    /// </summary>
    public string? Description { get; init; }
    
    /// <summary>
    /// Детальный план выступления
    /// </summary>
    public string? Outline { get; init; }

    /// <summary>
    /// Фабрика для создания ДТО из доменной модели
    /// </summary>
    /// <param name="application">Доменная модель заявки</param>
    /// <returns>ДТО заявки</returns>
    public static ApplicationView Create(Application? application)
    {
        return new ApplicationView
        {
            Id = application.Id,
            Author = application.AuthorId,
            Activity = application.ActivityType,
            Name = application.Name,
            Description = application.Description,
            Outline = application.Outline
        };
    }
}