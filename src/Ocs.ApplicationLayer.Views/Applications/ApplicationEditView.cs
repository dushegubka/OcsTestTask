using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Views.Applications;

/// <summary>
/// ДТО для редактирования заявки
/// </summary>
public class ApplicationEditView
{
    /// <summary>
    /// Тип активности
    /// </summary>
    public required ActivityType Activity { get; init; }

    /// <summary>
    /// Название заявки
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Краткое описание
    /// </summary>
    public string? Description { get; init; }
    
    /// <summary>
    /// Детальный план выступления
    /// </summary>
    public required string Outline { get; init; }
}