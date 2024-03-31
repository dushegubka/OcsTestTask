using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Applications;

public class ApplicationCreateView
{
    public required Guid Author { get; set; }

    public required ActivityType Activity { get; set; }

    public required string Name { get; set; }
    
    public string? Description { get; set; }

    public required string Outline { get; set; }
}