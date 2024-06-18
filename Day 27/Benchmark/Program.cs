using BenchmarkDotNet.Running;

class Program 
{
    static void Main()
    {
        // Jalanin Program ini pakai (dotnet run -c Release)
        //BenchmarkRunner.Run<StringVsStringBuilder>();

        BenchmarkRunner.Run<CollectionsBenchmark>();
    }
}