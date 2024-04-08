using FluentAssertions;
using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Exceptions;
using Ocs.ApplicationLayer.Views.Applications;
using Ocs.Domain.Applications;
using Ocs.Domain.Enums;
using Ocs.Infrastructure.Applications;

namespace Ocs.ApplicationLayer.Tests;

public class ApplicationServiceTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public ApplicationServiceTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        
        Initialize();
    }
    
    /*
    [Fact(DisplayName = "Должен бросить исключение при попытке создать заявку с несуществующим пользователем")]
    public async Task CreateAsync_Should_Throw_UserNotFoundException_When_User_Not_Found()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationCreateView = new ApplicationCreateView()
        {
            Activity = ActivityType.Report,
            Author = Guid.NewGuid(),
            Description = "Test",
            Name = "Test",
            Outline = "Test"
        };
        
        // Act 
        Func<Task> act = async () => await applicationService.CreateAsync(applicationCreateView);
        
        // Assert
        
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
    */
    
    [Fact(DisplayName = "Должен бросить исключение при попытке создать заявку с пользователем у которого уже есть черновик")]
    public async Task CreateAsync_Should_Throw_UserAlreadyHasDraftApplicationException_When_User_Has_Draft_Application()
    {
        // Arrange 
        var userId = Guid.NewGuid();
        var application = CreateTestApplication(userId);
        var applicationCreateView = CreateTestApplicationCreateView();
        applicationCreateView.Author = userId;

        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();
        
        await applicationRepository.CreateAsync(application);

        // Act
        Func<Task> act = () => applicationService.CreateAsync(applicationCreateView);
        
        // Assert
        await Assert.ThrowsAsync<UserAlreadyHasDraftApplicationException>(act);
    }
    
    // Ужасный тест согласен полностью.
    [Fact(DisplayName = "Должен просить исключение при попытке изменить подтвержденную заявку")]
    public async Task UpdateAsync_Should_Throw_SubmittedApplicationEditingException_When_Application_Submitted()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();

        var applicationEditView = CreateTestApplicationEditView();
        var application = CreateTestApplication();
        
        application.Submit();
        
        await applicationRepository.CreateAsync(application);
        
        // Act 
        var act = async () => await applicationService.UpdateAsync(application.Id, applicationEditView);
        
        // Assert
        await act.Should().ThrowAsync<SubmittedApplicationEditingException>();
    }

    [Fact(DisplayName = "Должен обновлять данные заявки")]
    public async Task UpdateAsync_Should_Update_Application_Record()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();
        
        var applicationEditView = CreateTestApplicationEditView();
        var application = CreateTestApplication();
        
        // Act
        await applicationRepository.CreateAsync(application);
        await applicationService.UpdateAsync(application.Id, applicationEditView);
        
        // Assert
        var updated = await applicationService.GetByIdAsync(application.Id);

        updated.Should().BeEquivalentTo(applicationEditView);
    }
    
    [Fact(DisplayName = "Должен просить исключение при попытке удалить подтвержденную заявку")]
    public async Task DeleteAsync_Should_Throw_SubmittedApplicationDeletingException_When_Application_Submitted()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();
        
        var application = CreateTestApplication();
        
        application.Submit();
        
        await applicationRepository.CreateAsync(application);
        
        // Act 
        var act = async () => await applicationService.DeleteAsync(application.Id);
        
        // Assert
        await act.Should().ThrowAsync<SubmittedApplicationDeletingException>();
    }
    
    [Fact(DisplayName = "Должен удалить заявку")]
    public async Task DeleteAsync_Should_Delete_Application_Record()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();
        
        var application = CreateTestApplication();
        
        // Act
        await applicationRepository.CreateAsync(application);
        await applicationService.DeleteAsync(application.Id);
        
        // Assert
        var applicationRecord = await applicationRepository.GetByIdAsync(application.Id);
        
        applicationRecord.Should().BeNull();
    }
    
    [Fact(DisplayName = "Должен подтвердить заявку")]
    public async Task SubmitAsync_Should_Submit_Application()
    {
        // Arrange
        var applicationService = ResolveApplicationService();
        var applicationRepository = ResolveApplicationRepository();
        
        var application = CreateTestApplication();
        
        // Act
        await applicationRepository.CreateAsync(application);
        var result = await applicationService.SubmitAsync(application.Id);
        
        // Assert
        result.Should().BeTrue();
    }

    private IApplicationService ResolveApplicationService()
    {
        var dbContext = _fixture.GetDbContext();
        var applicationRepository = new ApplicationRepository(dbContext);
        
        return new ApplicationService(applicationRepository);
    }
    
    private IApplicationRepository ResolveApplicationRepository()
    {
        var dbContext = _fixture.GetDbContext();
        return new ApplicationRepository(dbContext);
    }
    
    private Application CreateTestApplication()
    {
        return Application.Create(
            Guid.NewGuid(),
            Guid.NewGuid(),
            ActivityType.Report,
            "Test Name",
            "Test Description",
            "Test Outline");
    }
    
    private Application CreateTestApplication(Guid authorId)
    {
        return Application.Create(
            Guid.NewGuid(),
            authorId,
            ActivityType.Report,
            "Test Name",
            "Test Description",
            "Test Outline");
    }
    
    private ApplicationCreateView CreateTestApplicationCreateView()
    {
        return new ApplicationCreateView
        {
            Activity = ActivityType.Report,
            Author = Guid.NewGuid(),
            Description = "Test Create View",
            Name = "Test Create View",
            Outline = "Test Create View"
        };
    }
    
    private ApplicationEditView CreateTestApplicationEditView()
    {
        return new ApplicationEditView
        {
            Activity = ActivityType.Report,
            Description = "Test Edit View",
            Name = "Test Edit View",
            Outline = "Test Edit View"
        };
    }
    

    private void Initialize()
    {
        _fixture.GetDbContext().Database.EnsureCreated();
    }
}