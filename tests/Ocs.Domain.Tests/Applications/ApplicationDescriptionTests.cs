using FluentAssertions;
using Ocs.Domain.Applications;

namespace Ocs.Domain.Tests.Applications;

public class ApplicationDescriptionTests
{
    [Fact]
    public void ApplicationTitle_Create_WithValidValue_Should_Create_Successfully()
    {
        // Arrange
        const string value = "Расскажу что нас ждет в новом релизе!";
        
        // Act
        var title = ApplicationDescription.Create(value);
        
        // Assert
        title.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void ApplicationDescription_Create_Should_ThrowArgumentException_When_Value_IsNullOrEmpty(string? value)
    {
        // Act
        Action act = () => ApplicationDescription.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ApplicationDescription_Create_Should_ThrowArgumentOutOfRangeException_When_Value_IsGreaterThan300()
    {
        // Arrange
        var value = new string('a', 301);
        
        // Act
        Action act = () => ApplicationDescription.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ApplicationDescription_ChangeValue_Should_ChangeValue()
    {
        // Arrange
        const string value = "Напомню, что было в старом релизе!";
        const string newValue = "Расскажу, что нас ждет в новом релизе!";
        
        // Act
        var title = ApplicationDescription.Create(value);
        title.ChangeValue(newValue);
        
        // Assert
        title.Value.Should().Be(newValue);
        
    }
}