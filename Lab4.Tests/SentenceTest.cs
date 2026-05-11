using JetBrains.Annotations;
using Xunit;

namespace Lab4.Tests;

[TestSubject(typeof(Sentence))]
public class SentenceTest
{
    [Fact]
    public void ToString_ShouldReturnCleanedText()
    {
        // Arrange
        var sentence = new Sentence("Hello    world!!! ");
        
        // Act
        var result = sentence.ToString();

        // Assert
        Assert.Equal("Hello world!!! ", result);
    }
    
    [Fact]
    public void WordsCount_WhenDataIsEmpty_ShouldReturnZero()
    {
        // Arrange
        var sentence = "";
        var sentenceObj = new Sentence(sentence);

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void WordsCount_WhenDataHasWordsSeparatedBySpaces_ShouldReturnCorrectNumber()
    {
        // Arrange
        var sentenceObj = new Sentence("My  name  is  Alex?");

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void WordsCount_WhenDataHasDifferentSeparators_ShouldReturnCorrectNumber()
    {
        // Arrange
        var sentenceObj = new Sentence("Fruits:bananas,mangoes;apples — cool\tfood!");

        // Act
        var result = sentenceObj.WordsCount;

        // Assert
        Assert.Equal(6, result);
    }
}
