namespace ReverseTextLib;

class Program
{
    static void Main()
    {

    }
}

public class ReverseText
{
    public string Reverse(string text)
    {
        string result = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            result += text[i];
        }
        return result;
    }
}

