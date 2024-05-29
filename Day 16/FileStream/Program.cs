using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //Write
        //kenapa pake using
        using (FileStream fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            string text = "Selamat Pagi";
            byte[] myBytes = new byte[text.Length]; //buffer

            myBytes = Encoding.UTF8.GetBytes(text);
            fs.Write(myBytes, 0, myBytes.Length);
            Console.ReadLine();
        }

        Console.ReadLine();
        Console.WriteLine();

        //Read in terminal
        using (FileStream fs1 = File.OpenRead("test.txt"))
        {
            byte[] b = new byte[1024];
            UTF8Encoding tmp = new UTF8Encoding(true);
            int readLen;
             while ((readLen = fs1.Read(b, 0, b.Length))>0)
             {
                Console.WriteLine(tmp.GetString(b, 0, readLen));
             }
        }

        //Read
        using (var sr = new StreamReader("test.txt"))
        {
            Console.WriteLine(sr.ReadToEnd());
        }

    }
}