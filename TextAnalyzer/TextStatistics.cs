namespace TextAnalyzerApp;

public class TextStatistics
{
    public int CharacterCount { get; set; }

    public int CharacterCountWithoutSpaces { get; set; }

    public int LettersCount { get; set; }

    public int DigitsCount { get; set; }

    public int PunctuationsCount { get; set; }

    public int WordsCount { get; set; }
    
    public int DistinctWordsCount { get; set; }
    public string MostCommonWord { get; set; }

    public double AverageWordLength { get; set; }

    public (string Shortest, string Longest) ShortestAndLongestWord { get; set; }
    public int SentenceCount { get; set; }
    
    public double AverageWordsLengthPerSentence { get; set; }
    
    public string LongestSentence { get; set; }
    


    public TextStatistics(
        int characterCount, int characterCountWithoutSpaces, int lettersCount, int digitsCount,
        int punctuationsCount, int wordsCount, int distinctWordsCount, string mostCommonWord,
        double averageWordLength, (string Shortest, string Longest) shortestAndLongestWord,
        int sentenceCount, double averageWordsLengthPerSentence, string longestSentence)
    {
        CharacterCount = characterCount;
        CharacterCountWithoutSpaces = characterCountWithoutSpaces;
        LettersCount = lettersCount;
        DigitsCount = digitsCount;
        PunctuationsCount = punctuationsCount;
        WordsCount = wordsCount;
        DistinctWordsCount = distinctWordsCount;
        MostCommonWord = mostCommonWord;
        AverageWordLength = averageWordLength;
        ShortestAndLongestWord = shortestAndLongestWord;
        SentenceCount = sentenceCount;
        AverageWordsLengthPerSentence = averageWordsLengthPerSentence;
        LongestSentence = longestSentence;
    }

    public string PrintStatistics()
    {
        return $"Number of characters: {CharacterCount} \n" +
                        $"Number of characters without spaces: {CharacterCountWithoutSpaces} \n" +
                        $"Number of letters: {LettersCount} \n" +
                        $"Number of digits: {DigitsCount} \n" +
                        $"Number of punctuations: {PunctuationsCount} \n" +
                        $"Number of words: {WordsCount} \n" +
                        $"Number of distinct words: {DistinctWordsCount} \n" +
                        $"Most common word: {MostCommonWord} \n" +
                        $"Average word length: {AverageWordLength} \n" +
                        $"Shortest and longest word: {ShortestAndLongestWord}\n" +
                        $"Sentence: {SentenceCount} \n" +
                        $"Average words length per sentence: {AverageWordsLengthPerSentence} \n" +
                        $"Longest sentence: {LongestSentence}";
    }
}