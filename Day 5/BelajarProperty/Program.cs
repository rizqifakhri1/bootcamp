class Human 
{
    // untuk set karena di sini private maka untuk akses di mainnya harus pakai setBalace
    // kalau tidak private langsung bisa akses si balance  hm.Balance = 3000;

    // get {} set{} bisa di isi if else
    public int Balance{private get; set;}
    public void SetBalance(int balance)
    {
        Balance = balance;
    }

    public void PrintBalance()
    {
        System.Console.WriteLine(Balance);
    }

    public void AddBalance(int balance)
    {
        Balance += 10;
    }
}

class Program
{
    static void Main()
    {
        Human hm = new();
        hm.PrintBalance();
        

        hm.SetBalance(3000);
        hm.PrintBalance();
        //Console.WriteLine(hm.Balance); kalo getnya tidak private

         hm.AddBalance(3000);
        hm.PrintBalance();
        
    }
}