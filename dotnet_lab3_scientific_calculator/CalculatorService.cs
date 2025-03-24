namespace dotnet_lab3_scientific_calculator;

public class CalculatorService
{
    private Calculator calculator = new Calculator();
    private ScientificCalculator scientificCalculator = new ScientificCalculator();
    
    private void chooseNumbers(out double a, out double b)
    {
        Console.WriteLine("Enter first number: ");
        a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number: ");
        b = double.Parse(Console.ReadLine());
    }
    
    private void chooseNumbers(out double a)
    {
        Console.WriteLine("Enter number: ");
        a = double.Parse(Console.ReadLine());
    }

    private List<double> getSequence()
    {
        Console.WriteLine("Enter input: ");
        String[] input = Console.ReadLine().Split(' ');
        List<double> nums = new List<double>();
        double num;
        foreach (var item in input)
        {
            if (double.TryParse(item, out num))
            {
                nums.Add(num);
            }
            else
            {
                continue;
            }
        }

        return nums;
    }
    public void Run()
    {
        Console.WriteLine("Kalkulator naukowy w C#");
        bool isRunning = true;
        List<double> seq = new List<double>();
        double num1, num2;
        double res = 0;

        while (isRunning)
        {
            Console.WriteLine("Wybierz operację: +, -, *, /, ^, sqrt, log, sum, avg, min, max, exit");
            String chosenOperation = Console.ReadLine().Trim().ToLower();
            switch (chosenOperation)
            {
                case "+":
                    chooseNumbers(out num1, out num2);
                    res = calculator.Add(num1, num2);
                    break;
                case "-":
                    chooseNumbers(out num1, out num2);
                    res = calculator.Subtract(num1, num2);
                    break;
                case "*":
                    chooseNumbers(out num1, out num2);
                    res = calculator.Multiply(num1, num2);
                    break;
                case "/":
                    chooseNumbers(out num1, out num2);
                    if (num2 == 0)
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    res = calculator.Divide(num1, num2);
                    break;
                case "^":
                    chooseNumbers(out num1, out num2);
                    res = scientificCalculator.Power(num1, num2);
                    break;
                case "sqrt":
                    chooseNumbers(out num1);
                    if (num1 < 0)
                    {
                        Console.WriteLine("Negative number");
                        break;
                    }

                    res = scientificCalculator.SquareRoot(num1);
                    break;
                case "log":
                    chooseNumbers(out num1);
                    res = scientificCalculator.Log(num1);
                    break;
                case "sum":
                    seq = getSequence();
                    res = calculator.SumSequence(seq);
                    break;
                case "avg":
                    seq = getSequence();
                    res = calculator.AverageSequence(seq);
                    break;
                case "min":
                    seq = getSequence();
                    res = calculator.MinSequence(seq);
                    break;
                case "max":
                    seq = getSequence();
                    res = calculator.MaxSequence(seq);
                    break;
                case "exit":
                    isRunning = false;
                    break;
                default:
                    res = -1;
                    Console.WriteLine("Invalid input.");
                    break;
            }
            
            if(isRunning)
                Console.WriteLine($"Wynik operacji ({chosenOperation}) = {res}");
            
        }
    }
}