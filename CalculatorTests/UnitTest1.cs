namespace CalculatorTests;
using dotnet_lab3_scientific_calculator;
using NUnit.Framework;

public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnsCorrectResult()
    {
        double result = _calculator.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract_ReturnsCorrectResult()
    {
        double result = _calculator.Subtract(10, 4);
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Multiply_ReturnsCorrectResult()
    {
        double result = _calculator.Multiply(3, 5);
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Divide_ReturnsCorrectResult()
    {
        double result = _calculator.Divide(10, 2);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ReturnsInfinity()
    {
        double result = _calculator.Divide(10, 0);
        Assert.That(double.IsInfinity(result), Is.True);
    }

    [Test]
    public void SumSequence_ReturnsCorrectResult()
    {
        var sequence = new List<double> { 1, 2, 3, 4 };
        double result = _calculator.SumSequence(sequence);
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void AverageSequence_ReturnsCorrectResult()
    {
        var sequence = new List<double> { 2, 4, 6 };
        double result = _calculator.AverageSequence(sequence);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void MaxSequence_ReturnsCorrectResult()
    {
        var sequence = new List<double> { -5, 3, 9, 1 };
        double result = _calculator.MaxSequence(sequence);
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void MinSequence_ReturnsCorrectResult()
    {
        var sequence = new List<double> { 10, -1, 5, 7 };
        double result = _calculator.MinSequence(sequence);
        Assert.That(result, Is.EqualTo(-1));
    }
}
