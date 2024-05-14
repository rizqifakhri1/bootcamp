class Program
{
    
    static void Main()
    {
        SampleCompare sp = new SampleCompare();
        sp.CompareTo(null);
    }

}

public interface IComparable<T>
{
    int CompareTo(T other);
}

class SampleCompare : IComparable<string>
{
    public int CompareTo (string other)
    {
        int j = int.Parse(other);
    }
}