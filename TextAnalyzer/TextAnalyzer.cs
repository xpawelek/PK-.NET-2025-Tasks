namespace TextAnalyzerApp;

public class TextAnalyzer
{
    string[] SplitIntoWords(string str)
    {
        return str.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
    }
    
    string[] SplitIntoSentences(string str)
    {
        return str.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
    }
    public int CountCharacters(string text)
    {
        if (text == "") return 0;
        return text.Length;
    }

    public int CountCharactersWithoutSpaces(string text)
    {
        if (text == "") return 0;
        return text.Count(c=> !char.IsWhiteSpace(c));
    }

    public int CountOnlyLetters(string text)
    {
        if (text == "") return 0;
        return text.Count(char.IsLetter);
    }

    public int CountOnlyDigits(string text)
    {
        if (text == "") return 0;
        return text.Count(char.IsDigit);
    }

    public int CountOnlyPunctuations(string text)
    {
        if (text == "") return 0;
        return text.Count(char.IsPunctuation);
    }
    
    public int CountWords(string text)
    { 
        if (text == "") return 0;
        string[] words = SplitIntoWords(text);
        return words.Length;
    }

    public int CountDistinctWords(string text)
    {
        if (text == "") return 0;
        string[] words = SplitIntoWords(text);
        return words.Select(w => w.ToLower()).Distinct().Count();
    }
    public string FindMostCommonWord(string text)
    {
        if (text == "") return "";
        string[] words = SplitIntoWords(text);
        return words.Where(w => w.Length > 1).GroupBy(w => w.ToLower()).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
    }
    
    public double AverageWordLength(string text)
    {
        if (text == "") return 0;
        string[] words = SplitIntoWords(text);
        return Math.Round(words.Average(w => w.Length), 2);
    }

    public (string shortest, string longest) FindShortestAndLongestWord(string text)
    {
        var words = SplitIntoWords(text).Where(w => w.Length > 0).ToList();
        
        if (!words.Any()) return ("", "");
        return (words.Where(w => w.Length > 1).OrderByDescending(w => w.Length).LastOrDefault(), words.OrderByDescending(w => w.Length).FirstOrDefault());
    }
    
    public int CountSentences(string text)
    {
        if (text == "") return 0;
        string[] sentences = SplitIntoSentences(text);
        return sentences.Length;
    }

    public double AverageWordsPerSentence(string text)
    {
        if (text == "") return 0;
        string[] sentences = SplitIntoSentences(text);
        return Math.Round(sentences.Average(s=>CountWords(s)), 2);
    }

    public string LongestWordDependingOnQunatityOfWords(string text)
    {
        if (text == "") return "";
        string[] sentences = SplitIntoSentences(text);
        return sentences.OrderByDescending(s=> CountWords(s)).FirstOrDefault();
    }    
    
    public TextStatistics AnalyzeText(string text)
    {
        return new TextStatistics(
            CountCharacters(text),
            CountCharactersWithoutSpaces(text),
            CountOnlyLetters(text),
            CountOnlyDigits(text),
            CountOnlyPunctuations(text),
            CountWords(text),
            CountDistinctWords(text),
            FindMostCommonWord(text),
            AverageWordLength(text),
            FindShortestAndLongestWord(text),
            CountSentences(text),
            AverageWordsPerSentence(text),
            LongestWordDependingOnQunatityOfWords(text)
            );
    }
}