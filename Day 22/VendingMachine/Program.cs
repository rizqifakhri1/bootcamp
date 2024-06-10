namespace VendingMachine.Observer;

class Program
{
    static void Main(string[] args)
    {
        // Buat vending machine (subjek)
        VendingMachine vendingMachine = new VendingMachine();

        // Buat beberapa pengamat
        ManagerObserver manager = new ManagerObserver("Dewi");
        CustomerObserver customer = new CustomerObserver("Fadil");

        // Daftarkan pengamat ke vending machine
        vendingMachine.Attach(manager);
        vendingMachine.Attach(customer);

        // Ubah stok yang secara otomatis akan memberitahu semua pengamat
        Console.WriteLine("Setting stock to 5:");
        vendingMachine.Stock = 5;

        System.Console.WriteLine();
        
        // Ubah stok ke 0 yang akan memberitahu pengamat bahwa stok habis
        Console.WriteLine("Setting stock to 0:");
        vendingMachine.Stock = 0;

    }
}
