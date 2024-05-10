class Program 
{
    public static void Main()
    {
        int refParameter = 7;
        int inParameter = 23;
        int outParameter;


        ExampleMethod(ref refParameter, in inParameter, out outParameter);
        Console.WriteLine(refParameter);
        Console.WriteLine(inParameter);
        Console.WriteLine(outParameter);
    }

     public static void ExampleMethod(ref int refParameter, in int inParameter, out int outParameter)
        {
            //refParaeter dapat di ubah
            refParameter += 10;

            // inParameter tidak dapat diubah atau read only
            // inParameter =10 // menyebabkan error karena paramter in

            //outParamter harus diinisiasi
            outParameter = refParameter;
        }
}