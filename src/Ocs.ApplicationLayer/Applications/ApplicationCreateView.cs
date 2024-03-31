using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Applications;

/// <summary>
/// ДТО для создания заявки
/// </summary>
public class ApplicationCreateView
{
    /// <summary>
    /// Id автора заявки
    /// </summary>
    public required Guid Author { get; set; }

    /// <summary>
    /// Тип активности
    /// </summary>
    public required ActivityType Activity { get; set; }

    /// <summary>
    /// Название заявки
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Краткое описание заявки
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Детальный план выступления
    /// </summary>
    public required string Outline { get; set; }
}