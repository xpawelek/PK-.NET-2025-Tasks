namespace dotnet_lab3_scientific_calculator;

class Program
{
    static void Main(string[] args)
    {
        CalculatorService calculatorService = new CalculatorService();

        calculatorService.Run();
    }
}