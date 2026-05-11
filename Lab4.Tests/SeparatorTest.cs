using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests;

[TestSubject(typeof(Separator))]
public class SeparatorTest
{
    [Fact]
    public void GetStringValue_ShouldReturnInputCharAsString()
    {
        // Arrange
        var separatorObj = new Separator(':');

        // Act
        var result = separatorObj.GetStringValue();

        // Assert
        Assert.Equal(":", result);
    }
}