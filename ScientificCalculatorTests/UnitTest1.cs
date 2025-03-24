namespace ScientificCalculatorTests;
using dotnet_lab3_scientific_calculator;
using NUnit.Framework;

public class ScientificCalculatorTests
{
    private ScientificCalculator _scientificCalculator;

    [SetUp]
    public void Setup()
    {
        _scientificCalculator = new ScientificCalculator();
    }
    
    [Test]
    public void PositiveBasePositiveExponent_ReturnsCorrectResult()
    {
        double result = _scientificCalculator.Power(2, 3);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void ZeroBasePositiveExponent_ReturnsZero()
    {
        double result = _scientificCalculator.Power(0, 5);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void PositiveBaseZeroExponent_ReturnsOne()
    {
        double result = _scientificCalculator.Power(10, 0);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void NegativeBaseEvenExponent_ReturnsPositiveResult()
    {
        double result = _scientificCalculator.Power(-2, 2);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void NegativeBaseOddExponent_ReturnsNegativeResult()
    {
        double result = _scientificCalculator.Power(-2, 3);
        Assert.That(result, Is.EqualTo(-8));
    }

    [Test]
    public void Power_ZeroToZero_ReturnsOne()
    {
        double result = _scientificCalculator.Power(0, 0);
        Assert.That(result, Is.EqualTo(1)); 
    }
    
    [Test]
    public void SquareRoot_PerfectSquare_ReturnsExactRoot()
    {
        double result = _scientificCalculator.SquareRoot(25);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void SquareRoot_Zero_ReturnsZero()
    {
        double result = _scientificCalculator.SquareRoot(0);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void SquareRoot_NegativeNumber_ReturnsNaN()
    {
        double result = _scientificCalculator.SquareRoot(-9);
        Assert.That(double.IsNaN(result), Is.True);
    }
    
    [Test]
    public void LogE_ReturnsOne()
    {
        double result = _scientificCalculator.Log(Math.E);
        Assert.That(result, Is.EqualTo(1).Within(0.0001));
    }

    [Test]
    public void LogOne_ReturnsZero()
    {
        double result = _scientificCalculator.Log(1);
        Assert.That(result, Is.EqualTo(0).Within(0.0001));
    }

    [Test]
    public void LogZero_ReturnsNegativeInfinity()
    {
        double result = _scientificCalculator.Log(0);
        Assert.That(double.IsNegativeInfinity(result), Is.True);
    }

    [Test]
    public void LogNegativeNumber_ReturnsNaN()
    {
        double result = _scientificCalculator.Log(-5);
        Assert.That(double.IsNaN(result), Is.True);
    }
}
