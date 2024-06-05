namespace PersonLib;
class Program
{
        static void Main(){}

}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string GetFullName(Person person)
    {
        if (person == null) return null;
        return $"{person.FirstName} {person.LastName}";
    }
}