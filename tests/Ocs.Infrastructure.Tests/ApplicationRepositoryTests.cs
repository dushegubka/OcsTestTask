using FluentAssertions;
using Ocs.Domain.Applications;
using Ocs.Domain.Enums;
using Ocs.Infrastructure.Applications;
using Ocs.Infrastructure.Extensions;
using Xunit.Abstractions;

namespace Ocs.Infrastructure.Tests;

public class ApplicationRepositoryTests 
    : IClassFixture<DatabaseFixture>, IDisposable
{
    private readonly DatabaseFixture _fixture;
    private readonly ITestOutputHelper _output;

    public ApplicationRepositoryTests(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
        
        Initialize();
    }
    
    [Fact(DisplayName = "Должен создавать заявку")]
    public async Task Should_Create_Application_Record()
    {
        // Arrange 
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var application = CreateTestApplication();

        // Act
        await repository.CreateAsync(application);
        
        // Assert
        var applicationRecord = dbContext.Applications
            .SingleOrDefault(x => x.Id == application.Id);
        
        applicationRecord?.ToDomainModel()
            .Should().BeEquivalentTo(application);
    }
    
    [Fact(DisplayName = "Должен возвращать заявку по идентификатору")]
    public async Task GetById_Should_Return_Application_Record()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);

        var application = CreateTestApplication();
        
        await repository.CreateAsync(application);
        
        // Act
        var result = await repository.GetByIdAsync(application.Id);
        
        // Assert
        result.Should().BeEquivalentTo(application);
    }
    
    [Fact(DisplayName = "Должен удалять заявку по идентификатору")]
    public async Task DeleteAsync_Should_Delete_Application_Record()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var application = CreateTestApplication();
        
        await repository.CreateAsync(application);
        
        // Act
        await repository.DeleteAsync(application.Id);
        
        // Assert
        var applicationRecord = dbContext.Applications
            .SingleOrDefault(x => x.Id == application.Id);
        
        applicationRecord.Should().BeNull();
    }
    
    [Fact(DisplayName = "Должен подтвердить заявку")]
    public async Task SubmitAsync_Should_Submit_Application_Record()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var application = CreateTestApplication();
        
        await repository.CreateAsync(application);
        
        // Act
        await repository.SubmitAsync(application.Id);
        
        // Assert
        var applicationRecord = dbContext.Applications
            .SingleOrDefault(x => x.Id == application.Id);
        
        applicationRecord.Should().NotBeNull();
        applicationRecord!.IsSubmitted.Should().BeTrue();
    }
    
    [Fact(DisplayName = "Должен возвращать заявки, подтвержденные после определенной даты")]
    public async Task GetSubmittedAfterAsync_Should_Return_Applications_Submitted_After_Date()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var firstApplication = CreateTestApplication();
        var secondApplication = CreateTestApplication();
        
        var date = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        
        // Act
        firstApplication.Submit();
        secondApplication.Submit();

        await repository.CreateAsync(firstApplication);
        await repository.CreateAsync(secondApplication);
        
        var result = await repository.GetSubmittedAfterAsync(date);
        
        // Assert
        result.Count().Should().Be(2);
    }

    [Fact(DisplayName = "Должен возвращать заявки, неподтвержденные до определенной даты")]
    public async Task GetUnsubmittedOlderAsync_Should_Return_Applications_Unsubmitted_Before_Date()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var firstApplication = CreateTestApplication();
        var secondApplication = CreateTestApplication();
        
        var date = new DateTimeOffset(2024, 12, 1, 0, 0, 0, TimeSpan.Zero);
        
        // Act
        await repository.CreateAsync(firstApplication);
        await repository.CreateAsync(secondApplication);
        
        var result = await repository.GetUnsubmittedOlderAsync(date);
        
        // Assert
        result.Count().Should().Be(2);
    }

    [Fact(DisplayName = "Должен вернуть черновик заявки пользователя")]
    public async Task GetUserDraftApplicationAsync_ShouldReturn_User_Draft_Application()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var application = CreateTestApplication();
        
        // Act
        await repository.CreateAsync(application);
        
        var result = await repository.GetUserDraftApplicationAsync(application.AuthorId);
        
        // Assert
        result.Should().BeEquivalentTo(application);
    }
    
    [Fact(DisplayName = "Должен вернуть true, если у пользователя есть черновик заявки")]
    public async Task UserHasDraftApplication_ShouldReturn_True_If_User_Has_Draft_Application()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new ApplicationRepository(dbContext);
        var application = CreateTestApplication();
        
        // Act
        await repository.CreateAsync(application);
        
        var result = repository.UserHasDraftApplication(application.AuthorId);
        
        // Assert
        result.Should().BeTrue();
    }

    public void Dispose()
    {
        var context = _fixture.GetDbContext();
        context.Applications.RemoveRange(context.Applications);
        context.SaveChanges();
    }

    private void Initialize()
    {
        _fixture.GetDbContext().Database.EnsureCreated();
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
}