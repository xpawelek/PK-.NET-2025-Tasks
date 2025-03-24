namespace dotnet_lab3_scientific_calculator;

public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        return a / b;
    }

    public double SumSequence(IEnumerable<double> sequence)
    {
        double sum = 0;
        foreach (var variable in sequence)
        {
            sum += variable;
        }

        return sum;
    }

    public double AverageSequence(IEnumerable<double> sequence)
    {
        double sum = 0;
        double count = 0;
        foreach (var variable in sequence)
        {
            sum += variable;
            count++;
        }
        return Math.Round((sum / count));
    }

    public double MaxSequence(IEnumerable<double> sequence)
    {
        double max = double.MinValue;
        foreach (var variable in sequence)
        {
            if (variable > max)
                max = variable;
        }
        return max;
    }

    public double MinSequence(IEnumerable<double> sequence)
    {
        double min = double.MaxValue;
        foreach (var variable in sequence)
        {
            if (variable < min)
            {
                min = variable;
            }
        }

        return min;
    }
}