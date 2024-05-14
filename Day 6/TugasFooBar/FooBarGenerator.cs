class FooBarGenerator
{
    //Mengenkapsulasi field dari FooBarGenerator
    //agar hanya dapat di akses di dalam class
    private const string Foo = "Foo";
    private const string Bar = "Bar";
    private const string FooBar = "FooBar";

    public List<string> Generate(int maxNumber)
    {
        List<string> results = new List<string>();
        for (int i = 1; i <= maxNumber; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                results.Add(FooBar);
            }
            else if (i % 3 == 0)
            {
                results.Add(Foo);
            }
            else if (i % 5 == 0)
            {
                results.Add(Bar);
            }
            else
            {
                results.Add(i.ToString());
            }
        }
        return results;
    }
}
