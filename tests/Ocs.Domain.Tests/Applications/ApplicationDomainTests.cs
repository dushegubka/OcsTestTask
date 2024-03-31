using FluentAssertions;
using Ocs.Domain.Applications;
using Ocs.Domain.Enums;

namespace Ocs.Domain.Tests.Applications;

public class ApplicationDomainTests
{
    [Fact(DisplayName = "При создании заявки все поля должны корректно заполняться")]
    public void Application_Create_Should_Correctly_Fill_Required_Properties()
    {
        // Arrange
        var applicationId = Guid.NewGuid();
        var authorId = Guid.NewGuid();
        var title = ApplicationName.Create("Новые фичи C# vNext");
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
        application.Name.Should().Be(title);
        application.Description.Should().Be(description);
        application.Outline.Should().Be(outline);
    }
    
    [Fact(DisplayName = "Должен изменить тип активности")]
    public void Application_ChangeActivityType_Should_Change_ActivityType()
    {
        // Arrange
        var application = CreateApplication();
        
        // Act
        application.ChangeActivityType(ActivityType.Discussion);
        
        // Assert
        application.ActivityType.Should().Be(ActivityType.Discussion);
    }
    
    [Fact(DisplayName = "Должен изменить название")]
    public void Application_ChangeName_Should_Change_Name()
    {
        // Arrange
        var application = CreateApplication();

        var newName = ApplicationName.Create("Новое название");
        
        // Act
        application.ChangeName(newName);
        
        // Assert
        application.Name.Should().Be(newName);
    }
    
    [Fact(DisplayName = "Должен изменить план доклада")]
    public void Application_ChangeOutline_Should_Change_Outline()
    {
        // Arrange
        var application = CreateApplication();
        
        var newOutline = ApplicationOutline.Create("новый план доклада");
        
        // Act
        application.ChangeOutline(newOutline);
        
        // Assert
        application.Outline.Should().Be(newOutline);
    }
    
    [Fact(DisplayName = "Должен изменить описание")]
    public void Application_ChangeDescription_Should_Change_Description()
    {
        // Arrange
        var application = CreateApplication();
        
        var newDescription = ApplicationDescription.Create("Новое описание");
        
        // Act
        application.ChangeDescription(newDescription);
        
        // Assert
        application.Description.Should().Be(newDescription);
    }
    
    [Fact(DisplayName = "Должен пометить заявку как отправленную")]
    public void Application_Submit_Should_Change_IsSubmitted()
    {
        // Arrange
        var application = CreateApplication();
        
        // Act
        application.Submit();
        
        // Assert
        application.IsSubmitted.Should().BeTrue();
    }

    private Application CreateApplication()
    {
        var applicationId = Guid.NewGuid();
        var authorId = Guid.NewGuid();
        var name = ApplicationName.Create("Новые фичи C# vNext");
        var description = ApplicationDescription.Create("Расскажу что нас ждет в новом релизе!");
        var outline = ApplicationOutline.Create("очень много текста... прямо детальный план доклада!");
        
        
        return Application.Create(
            applicationId,
            authorId,
            ActivityType.Report,
            name,
            description,
            outline
        );
    }
}