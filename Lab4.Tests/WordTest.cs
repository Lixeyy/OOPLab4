using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests;

[TestSubject(typeof(Word))]
public class WordTest
{
    [Fact]
    public void GetStringValue_ShouldReturnInputString()
    {
        // Arrange
        var wordObj = new Word("myLongWord");

        // Act
        var result = wordObj.GetStringValue();

        // Assert
        Assert.Equal("myLongWord", result);
    }
}