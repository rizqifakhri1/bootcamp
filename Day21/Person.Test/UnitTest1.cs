namespace Person.Test;
using PersonLib;

public class Tests
{
    private Person _person;
    [SetUp]
    public void Setup()
    {
        _person = new Person();
    }

    [Test]
    public void FullName_ReturnCorrectValue()
    {
        //Arrage
        var rizqi = new Person()
        {
            FirstName = "Rizqi",
            LastName = "FK"
        };
        //Act
        var result = _person.GetFullName(rizqi);
        //Assert
        Assert.AreEqual("Rizqi FK", result);
    }

    [Test]
    public void GetFullName_WhenCalledwithNull_ReturnNull()
    {
        //Act
        var result = _person.GetFullName(null);
        //Assert
        // Assert.AreEqual(null, result);
        Assert.IsNull(result);
    }
}