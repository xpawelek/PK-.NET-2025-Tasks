using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lab12_Analysis;

class Program
{
    static readonly string[] urls =
    {
        "https://www.gutenberg.org/files/84/84-0.txt",
        "https://www.gutenberg.org/files/11/11-0.txt",
        "https://www.gutenberg.org/files/1661/1661-0.txt",
        "https://www.gutenberg.org/files/2701/2701-0.txt"
    };

    static readonly HttpClient client = new HttpClient();
    static readonly ConcurrentDictionary<string, int> wordCounts = new ConcurrentDictionary<string, int>();

    static async Task Main()
    {
        Stopwatch downloadTimer = Stopwatch.StartNew();
        var downloadTasks = urls.Select(url => DownloadTextAsync(url)).ToArray();
        string[] texts = await Task.WhenAll(downloadTasks);
        downloadTimer.Stop();

        Stopwatch processingTimer = Stopwatch.StartNew();
        Parallel.ForEach(texts, text => ProcessText(text));
        processingTimer.Stop();

        var topWords = wordCounts.OrderByDescending(kvp => kvp.Value).Take(10);

        Console.WriteLine("Najczęstsze słowa:");
        int rank = 1;
        foreach (var kvp in topWords)
        {
            Console.WriteLine($"{rank++}. {kvp.Key}: {kvp.Value}");
        }

        Console.WriteLine($"\nCzas pobierania: {downloadTimer.Elapsed.TotalSeconds:F2} sekundy");
        Console.WriteLine($"Czas przetwarzania: {processingTimer.Elapsed.TotalSeconds:F2} sekundy");
    }

    static async Task<string> DownloadTextAsync(string url)
    {
        return await client.GetStringAsync(url);
    }

    static void ProcessText(string text)
    {
        string[] words = Regex.Split(text.ToLowerInvariant(), "[^a-zA-Z']+")
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .ToArray();

        foreach (string word in words)
        {
            wordCounts.AddOrUpdate(word, 1, (_, oldCount) => oldCount + 1);
        }
    }
}


/*
Pytania do refleksji:

1. 
Użyto Parallel.ForEach do równoległego przetwarzania tekstów oraz ConcurrentDictionary do bezpiecznego współdzielenia danych między wątkami.

2. Dlaczego synchronizacja była konieczna?
Ponieważ wiele wątków jednocześnie modyfikuje ten sam słownik - potrzebna była synchronizacja, by uniknąć konfliktów i błędów.

3. Jak wyglądałby ten kod bez równoległości? Co by się zmieniło?
Zamiast Parallel.ForEach byłaby zwykła pętla foreach, a ConcurrentDictionary można by zastąpić zwykłym Dictionary - ale kod działałby wolniej.

4. Jak można jeszcze poprawić wydajność?
Można zliczać słowa lokalnie w osobnych słownikach, a dopiero potem je scalać - zmniejsza to liczbę operacji na wspólnej strukturze.
*/
