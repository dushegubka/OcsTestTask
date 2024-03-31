using FluentAssertions;
using Ocs.Domain.Applications;

namespace Ocs.Domain.Tests.Applications;

public class ApplicationOutlineTests
{
    [Fact]
    public void ApplicationTitle_Create_WithValidValue_Should_Create_Successfully()
    {
        // Arrange
        const string value = "очень много текста... прямо детальный план доклада!";
        
        // Act
        var title = ApplicationOutline.Create(value);
        
        // Assert
        title.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void ApplicationOutline_Create_Should_ThrowArgumentException_When_Value_IsNullOrEmpty(string? value)
    {
        // Act
        Action act = () => ApplicationOutline.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ApplicationOutline_Create_Should_ThrowArgumentOutOfRangeException_When_Value_IsGreaterThan1000()
    {
        // Arrange
        var value = new string('a', 1001);
        
        // Act
        Action act = () => ApplicationOutline.Create(value);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}