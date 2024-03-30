using FluentAssertions;
using Ocs.Domain.Applications;
using Ocs.Domain.Enums;

namespace Ocs.Domain.Tests.Applications;

public class ApplicationDomainTests
{
    [Fact]
    public void Application_Create_Should_Correctly_Fill_Required_Properties()
    {
        // Arrange
        var applicationId = Guid.NewGuid();
        var authorId = Guid.NewGuid();
        var title = ApplicationTitle.Create("Новые фичи C# vNext");
        var description = ApplicationDescription.Create("Расскажу что нас ждет в новом релизе!");
        var outline = ApplicationOutline.Create("очень много текста... прямо детальный план доклада!");

        // Act
        var application = Application.Create(
            applicationId,
            authorId,
            ActivityType.Report,
            title,
            description,
            outline
        );
        
        // Assert
        application.Id.Should().Be(applicationId);
        application.AuthorId.Should().Be(authorId);
        application.ActivityType.Should().Be(ActivityType.Report);
        application.Title.Should().Be(title);
        application.Description.Should().Be(description);
        application.Outline.Should().Be(outline);
    }
}