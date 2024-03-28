using Domain.Applications;
using FluentAssertions;

namespace Ocs.Domain.Tests.Applications;

public class ApplicationTitleTests
{
    [Fact]
    public void ApplicationTitle_Create_WithValidValue_Should_Create_Successfully()
    {
        // Arrange
        const string value = "Новые фичи C# vNext";
        
        // Act
        var title = ApplicationTitle.Create(value);
        
        // Assert
        title.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void ApplicationTitle_Create_Should_ThrowArgumentException_When_Value_IsNullOrEmpty(string? value)
    {
        // Act
        Action act = () => ApplicationTitle.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ApplicationTitle_Create_Should_ThrowArgumentOutOfRangeException_When_Value_IsGreaterThan100()
    {
        // Arrange
        var value = new string('a', 101);
        
        // Act
        Action act = () => ApplicationTitle.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ApplicationTitle_ChangeValue_Should_ChangeValue()
    {
        // Arrange
        const string value = "Старые фичи C# vNext";
        const string newValue = "Новые фичи C# vNext";
        
        // Act
        var title = ApplicationTitle.Create(value);
        title.ChangeValue(newValue);
        
        // Assert
        title.Value.Should().Be(newValue);
        
    }
}