namespace TextAnalyzerApp;

class Program
{
    static void Main(string[] args)
    {
        int choose_input = -1; 
        Console.WriteLine("Enter 1 - console\nEnter 2 - File\nEnter 3 - args");
        
        while (true)
        {
            Console.WriteLine("Your choice: "); 
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out choose_input) && choose_input >= 1 && choose_input <= 3)
            {
                break;
            }
            
            Console.WriteLine("Invalid input. Try again.");
        }

        string textToAnalyze = "";
        string filePath;
        switch (choose_input)
        {
            case 1:
                textToAnalyze = Console.ReadLine();
                break;
            case 2:
                Console.WriteLine("Please enter the file path: ");
                filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    textToAnalyze = handle_file_reading(filePath);
                }
                break;
            case 3:
                if (args.Length == 0)
                {
                    Console.WriteLine("The file path is empty.");
                    break;
                }
                
                filePath = args[0];
                if (File.Exists(filePath))
                {
                    textToAnalyze = handle_file_reading(filePath);
                }
                break;
        }
        
        TextAnalyzer textAnalyzer = new TextAnalyzer();
        TextStatistics textStatistics = textAnalyzer.AnalyzeText(textToAnalyze);
        Console.WriteLine($"Statystyki: \n{textStatistics.PrintStatistics()}");
    }
    static string handle_file_reading(string filePath)
    {
        string content = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(content))
        {
            return "This file is empty.";
        }
        return File.ReadAllText(filePath);
    }
}