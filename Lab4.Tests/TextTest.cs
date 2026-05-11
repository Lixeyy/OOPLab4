using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests;

[TestSubject(typeof(Text))]
public class TextTest
{
    [Fact]
    public void ToString_ShouldReturnCleanedText()
    {
        // Arrange
        var textObj = new Text(" Grammar is cool!  Thank you. ");

        // Act
        var result = textObj.ToString();

        // Assert
        Assert.Equal("Grammar is cool! Thank you.", result);
    }

    [Fact]
    public void GetSortedSentences_WhenTextIsEmpty_ShouldReturnEmptyArray()
    {
        // Arrange
        var textObj = new Text("");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetSortedSentences_WhenTextHasTrailingSpaces_ShouldReturnTrimmedSentence()
    {
        // Arrange
        var textObj = new Text(" Hello World! ");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Single(result);
        Assert.Equal("Hello World!", result[0].ToString());
        Assert.Equal(2, result[0].WordsCount);
    }

    [Fact]
    public void GetSortedSentences_WhenSentencesSeparatedBySingleSeparators_ShouldReturnSortedSentencesWithSeparators()
    {
        // Arrange
        var textObj = new Text("Hi! Is it Ok? Red, blue, green - are colors. Check;Test.The end");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(5, result.Length);
        Assert.Equal("Hi!", result[0].ToString());
        Assert.Equal("Check;Test.", result[1].ToString());
        Assert.Equal("The end", result[2].ToString());
        Assert.Equal("Is it Ok?", result[3].ToString());
        Assert.Equal("Red, blue, green - are colors.", result[4].ToString());
    }

    [Fact]
    public void GetSortedSentences_WhenSentencesSeparatedByMultipleSeparators_ShouldReturnSentencesWithAllSeparators()
    {
        // Arrange
        var textObj = new Text("Let start... What?! It is amazing!!!! The end.");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(4, result.Length);
        Assert.Equal("What?!", result[0].ToString());
        Assert.Equal("Let start...", result[1].ToString());
        Assert.Equal("The end.", result[2].ToString());
        Assert.Equal("It is amazing!!!!", result[3].ToString());
    }

    [Fact]
    public void GetSortedSentences_WhenTextHasEmptySentences_ShouldOmitThem()
    {
        // Arrange
        var textObj = new Text("!Що буде далі? . Не знаю. ?");

        // Act
        var result = textObj.GetSortedSentences();

        // Assert
        Assert.Equal(2, result.Length);
        Assert.Equal("Не знаю.", result[0].ToString());
        Assert.Equal("Що буде далі?", result[1].ToString());
    }

    [Fact]
    public void GetSortedSentences_ShouldNotChangeData()
    {
        // Arrange
        var textObj = new Text("Привіт усім! Я Олексій. Усе ");

        // Act
        var result = textObj.GetSortedSentences();
        var textData = textObj.ToString();

        // Assert
        Assert.Equal("Привіт усім! Я Олексій. Усе", textData);
        Assert.Equal("Усе", result[0].ToString());
    }
}
