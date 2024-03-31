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
    public void ApplicationDescription_Create_Should_ThrowArgumentException_When_Value_IsNull(string? value)
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
}