namespace Calculator.Test.X;
using CalculatorLib;

public class CalculatorTest
{
    private Calculator _calculator;
    public  CalculatorTest()
    {
        _calculator = new();
    }
    [Fact]
    public void Add_ReturnCorrectValue()
    {
        //Arrange
        int a = 2;
        int b = 4;
        int expected = 6;
        //Action
        int result = _calculator.Add(a, b);
        //Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(1, 3, 4)]
    [InlineData(7, 8, 15)]
    [InlineData(0,0,0)]
    public void Add_ReturnCorrectValue_UsingInlineData(int a, int b, int expected)
    {
        //Action
        int result = _calculator.Add(a, b);
        //Assert
        Assert.Equal(expected, result);
    }
}