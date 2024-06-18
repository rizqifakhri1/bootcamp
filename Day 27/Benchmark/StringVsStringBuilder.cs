
using System.Text;
using BenchmarkDotNet.Attributes;



[MemoryDiagnoser]
public class StringVsStringBuilder
{
    [Params (10,100,1000)] // Untuk iterasi
    public int iterationNumber;

    [Benchmark]
    public string MyString(){
        string str = String.Empty;
        
        for(int i=0; i< iterationNumber ; i++){
            str += i;
        }
        return str;
    }

    [Benchmark]
    public string MyStringBuilder(){
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i< iterationNumber ; i++){
            sb.Append(i);
        }
        return sb.ToString();
    }

}
