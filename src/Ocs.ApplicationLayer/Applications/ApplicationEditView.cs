using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Applications;

public class ApplicationEditView
{
    public required ActivityType Activity { get; init; }

    public required string Name { get; init; }
    
    public string? Description { get; init; }
    
    public required string Outline { get; init; }
}