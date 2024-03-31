using FluentAssertions;
using Ocs.Domain.Users;
using Ocs.Infrastructure.Extensions;
using Ocs.Infrastructure.Users;

namespace Ocs.Infrastructure.Tests;

public class UserRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public UserRepositoryTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        
        Initialize();
    }
    
    [Fact(DisplayName = "Должен создавать пользователя")]
    public async Task Should_Create_User()
    {
        // Arrange
        var dbContext = _fixture.GetDbContext();
        var repository = new UserRepository(dbContext);
        var user = CreateUser();
        
        // Act
        await repository.CreateAsync(user);
        
        // Assert
        var userRecord = dbContext.Users
            .SingleOrDefault(x => x.Id == user.Id);
        
        userRecord?.ToDomainModel()
            .Should().BeEquivalentTo(user);
    }

    private User CreateUser()
    {
        return User.Create(Guid.NewGuid(), UserName.Create("Admin"));
    }

    private void Initialize()
    {
        _fixture.GetDbContext().Database.EnsureCreated();
    }
}