using FluentAssertions;
using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Views.Users;
using Ocs.Infrastructure.Users;

namespace Ocs.ApplicationLayer.Tests;

public class UserServiceTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public UserServiceTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        
        Initialize();
    }
    
    [Fact(DisplayName = "Должен создавать пользователя")]
    public async Task Should_Create_User()
    {
        // Arrange
        var userService = ResolveUserService();
        var userCreateView = new UserCreateView
        {
            Name = "Admin"
        };
        
        // Act
        var result = await userService.CreateAsync(userCreateView);
        
        // Assert
        result.Should().NotBeNull();
        result.Name.Should().BeEquivalentTo(userCreateView.Name);
    }

    private void Initialize()
    {
        _fixture.GetDbContext().Database.EnsureCreated();
    }

    private IUserService ResolveUserService()
    {
        var dbContext = _fixture.GetDbContext();
        var userRepository = new UserRepository(dbContext);
        return new UserService(userRepository);
    }
}