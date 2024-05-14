using System.Collection;
using System.Collection.Generic;


class program
{
    static void Main()
    {
        //Enumerator
        List<string> bp = new() { "Lisa", "Jeni", "Burhan", "Rose" };
        IEnumerator<string> enumerator = bp.GetEnumerator();
        while (enumerator.MoveNext())
        {
            System.Console.WriteLine(enumerator.Current);
        }

        //Iterator
        // public static IEnumerable<int> GetNumber()
        // {
        //     for(i)
        // }
    }
}
