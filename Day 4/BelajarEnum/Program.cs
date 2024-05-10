public enum Hewan 
{
    Gajah = 5,
    Jerapah = 7,
    Kucing = 0, 
    KudaLiar,
    KeptingKikir,
    CumiDarat,
    TupaiTerbang = 1 //Harus Unik kalau tidak akan ada dua nilai yang sama
}

class Program
{
    static void Main()
    {
        Hewan gajah = Hewan.Gajah;
        Console.WriteLine(gajah);

        int kudaLiar = (int)Hewan.KudaLiar;
        Console.WriteLine(kudaLiar);

        int cumiDarat = (int)Hewan.CumiDarat;
        Console.WriteLine(cumiDarat);

        int tupaiTerbang = (int)Hewan.TupaiTerbang;
        Console.WriteLine(tupaiTerbang);
    }
}