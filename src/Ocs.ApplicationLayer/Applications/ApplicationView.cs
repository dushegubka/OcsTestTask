using Ocs.Domain.Applications;
using Ocs.Domain.Enums;

namespace Ocs.ApplicationLayer.Applications;

public class ApplicationView
{
    public Guid Id { get; init; }
    
    public Guid Author { get; init; }
    
    public ActivityType Activity { get; init; }

    public string? Name { get; init; }
    
    public string? Description { get; init; }
    
    public string? Outline { get; init; }

    public static ApplicationView Create(Application? application)
    {
        return new ApplicationView
        {
            Id = application.Id,
            Author = application.AuthorId,
            Activity = application.ActivityType,
            Name = application.Name.Value,
            Description = application.Description.Value,
            Outline = application.Outline.Value
        };
    }
}