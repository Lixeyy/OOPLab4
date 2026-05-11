using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests;

[TestSubject(typeof(Letter))]
public class LetterTest
{
    [Fact]
    public void Data_ShouldReturnInputChar()
    {
        // Arrange
        var letterObj = new Letter('Ф');

        // Act
        var result = letterObj.Data;

        // Assert
        Assert.Equal('Ф', result);
    }
}