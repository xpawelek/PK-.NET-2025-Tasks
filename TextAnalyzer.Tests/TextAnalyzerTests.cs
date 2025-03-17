namespace TextAnalyzer.Tests;

using NUnit.Framework;
using System.Collections.Generic;
using TextAnalyzer;
using TextAnalyzerApp;

[TestFixture]
public class TextAnalyzerTests
{
    [Test]
    public void CountCharacters_ShouldReturnCorrectNumber()
    {
        var text = "Hello, world!";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountCharacters(text);
        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void CountWords_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountWords(text);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void CountSentences_ShouldReturnCorrectNumber()
    {
        var text = "Hello world! How are you? I am fine.";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountSentences(text);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void MostCommonWord_ShouldReturnCorrectWord()
    {
        var text = "apple banana applE orange aPple banana banana";
        var analyzer = new TextAnalyzer();
        string result = analyzer.FindMostCommonWord(text);
        Assert.That(result, Is.EqualTo("apple"));
    }

    [Test]
    public void Sentences_ShouldReturnCorrectSentenceLength()
    {
        var text = "Hello! How are you? I am fine.";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountSentences(text);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void LongestShortestWord_ShouldReturnCorrectLongestAndShortestWord()
    {
        var text = "Hello! How are you? Thats the longest sentence axaxaxax length is. A car.";
        var analyzer = new TextAnalyzer();
        var result = analyzer.FindShortestAndLongestWord(text);
        Assert.That(result, Is.EqualTo(("is", "sentence")));
    }
    
    [Test]
    public void WordsCount_ShouldReturnCorrectWordCount()
    {
        var text = "Hello! How are you? Thats the longest sentence length is.";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountWords(text);
        Assert.That(result, Is.EqualTo(10));
    }
    
    [Test]
    public void DistinctWordsCount_ShouldReturnCorrectDistinctWordsCount()
    {
        var text = "Sky sky BLUE blue wHiTe white";
        var analyzer = new TextAnalyzer();
        int result = analyzer.CountDistinctWords(text);
        Assert.That(result, Is.EqualTo(3));
    }


    [Test]
    public void CountDigitsAndPunctanceAndWhitespace_ShouldReturnCorrectNumber()
    {
        var text = "   123  !!!!!  456   .....";
        var analyzer = new TextAnalyzer();
        var result = analyzer.AnalyzeText(text);
        
        Assert.That(result.DigitsCount, Is.EqualTo(6));
        Assert.That(result.PunctuationsCount, Is.EqualTo(10));
        Assert.That(result.CharacterCountWithoutSpaces, Is.EqualTo(16));
    }
    
    [Test]
    public void AverageWordsLength_ShouldReturnCorrectAverageLength()
    {
        var text = "     sixsix . fivee";
        var analyzer = new TextAnalyzer();
        var result = analyzer.AverageWordLength(text);
        
        Assert.That(result, Is.EqualTo(5.50));
    }
    
    [Test]
    public void AnalyzeText_WithEmptyString_ShouldReturnZeroes()
    {
        var text = "";
        var analyzer = new TextAnalyzer();
        var result = analyzer.AnalyzeText(text);
        
        Assert.That(result.CharacterCount, Is.EqualTo(0));
        Assert.That(result.CharacterCountWithoutSpaces, Is.EqualTo(0));
        Assert.That(result.LettersCount, Is.EqualTo(0));
        Assert.That(result.DigitsCount, Is.EqualTo(0));
        Assert.That(result.PunctuationsCount, Is.EqualTo(0));
        Assert.That(result.WordsCount, Is.EqualTo(0));
        Assert.That(result.DistinctWordsCount, Is.EqualTo(0));
        Assert.That(result.MostCommonWord, Is.EqualTo(""));
        Assert.That(result.AverageWordLength, Is.EqualTo(0));
        Assert.That(result.ShortestAndLongestWord, Is.EqualTo(("", "")));
        Assert.That(result.SentenceCount, Is.EqualTo(0));
        Assert.That(result.AverageWordLength, Is.EqualTo(0));
        Assert.That(result.LongestSentence, Is.EqualTo(""));
    }
}