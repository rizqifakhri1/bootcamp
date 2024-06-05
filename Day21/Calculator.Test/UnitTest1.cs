namespace Calculator.Test;
using CalculatorLib;

public class Tests
{
    private Calculator calculator;
    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnCorrectValue()
    {
        //AAA
        //Arrange
        int a = 2;
        int b = 4;
        int expected = 6;

        //Action
        // Action action = () => calculator.Add(2, 3);
        int result = calculator.Add(a,b);

        //Assert
        //Memastikan
        // Assert.That(calculator.Add(2, 3), Is.EqualTo(5));
        Assert.AreEqual(expected, result);

    }

    [TestCase(1,3,4)] // a , b, expected
    [TestCase(7,8,15)] // contoh benar
    [TestCase(0,0,0)] //contoh benar
    [TestCase(1,1,2)] //contoh error
    public void Add_ReturnCorrectValue_UsingTestCase(int a, int b, int expected)
    {
        int result = calculator.Add(a, b);
        Assert.AreEqual(expected, result);
    }

    public void Min_ReturnCorrectValue()
    {
        int a = 10;
        int b = 5;
        int expected = 5;
        int result = calculator.Min(a, b);
        Assert.AreEqual(expected, result);
    }

    [TestCase(10,5,5)]
    [TestCase(10,10,0)]
    [TestCase(0,0,0)]
    public void Min_ReturnCorrectValue_UsingTestCase(int a, int b, int expected)
    {
        int result = calculator.Min(a, b);
        Assert.AreEqual(expected, result);
    }
} 