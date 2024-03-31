using Ocs.Domain.Applications;
using Ocs.Infrastructure.Applications;

namespace Ocs.Infrastructure.Extensions;

public static class ApplicationExtensions
{
    public static ApplicationEntity ToDatabaseEntity(this Application application)
    {
        return new ApplicationEntity
        {
            Id = application.Id,
            AuthorId = application.AuthorId,
            ActivityType = application.ActivityType,
            Title = application.Name.Value,
            Description = application.Description.Value,
            Outline = application.Outline.Value,
            SubmittedAt = application.SubmittedAt,
            CreatedAt = application.CreatedAt,
            IsSubmitted = application.IsSubmitted
        };
    }

    public static Application ToDomainModel(this ApplicationEntity application)
    {
        return Application.Create(
            application.Id,
            application.AuthorId,
            application.ActivityType,
            ApplicationName.Create(application.Title),
            ApplicationDescription.Create(application.Description),
            ApplicationOutline.Create(application.Outline),
            application.SubmittedAt,
            application.CreatedAt,
            application.IsSubmitted
        );
    }
}