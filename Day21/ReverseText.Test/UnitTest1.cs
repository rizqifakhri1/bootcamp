namespace ReverseText.Test;
using ReverseTextLib;

public class Tests
{
    private ReverseText reverseText;
    [SetUp]
    public void Setup()
    {
        reverseText = new ReverseText();
    }

    [Test]
    //AAA

    //Arrange
    public void Reverse_ReturnReverseString()
    {
        //AAA
        //Arrange
        string text = "Hello World";
        string expected = "dlroW olleH";
        //Action
        string result = reverseText.Reverse(text);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestCase("Hallo", "ollaH")]
    [TestCase("Rizqi", "iqziR")]
    // [TestCase("", "hehehe")]
    public void Reverse_ReturnReverseString_UsingTestCase(string text, string expected)
    {
        string result = reverseText.Reverse(text);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Reverse_WhenCallWithNoEmptyString_ReturnReverseString()
    {
        //Arrange
        string text = "";
        string expected = "";
        //Action
        string result = reverseText.Reverse(text);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestCase("", "")]
    public void Reverse1_WhenCallWithNoEmptyString_ReturnReverseString_UsingTestCase(string text, string expected)
    {
        string result = reverseText.Reverse(text);
        Assert.AreEqual(expected, result);
    }
}