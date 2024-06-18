namespace VendingMachine.Observer;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Buat vending machine (subjek)
        VendingMachine vendingMachine = new VendingMachine();

        // Buat beberapa pengamat
        ManagerObserver manager = new ManagerObserver("Dewi");
        CustomerObserver customer = new CustomerObserver("Fadil");
        CustomerObserver customer1 = new CustomerObserver("Ega");
        CustomerObserver customer2 = new CustomerObserver("Jun");

        // Daftarkan pengamat ke vending machine
        vendingMachine.Attach(manager);
        vendingMachine.Attach(customer);
        vendingMachine.Attach(customer1);
        vendingMachine.Attach(customer2);

        // Ubah stok yang secara otomatis akan memberitahu semua pengamat
        Console.WriteLine("Setting stock to 5:");
        vendingMachine.Stock = 5;


        // Lepas pengamat customer1
        vendingMachine.Detach(customer1);

        System.Console.WriteLine();
        System.Console.WriteLine("---------------------------------------------------");
        System.Console.WriteLine();

        // Ubah stok ke 0 yang akan memberitahu pengamat bahwa stok habis
        Console.WriteLine("Setting stock to 0:");
        vendingMachine.Stock = 0;

         System.Console.WriteLine();
        System.Console.WriteLine("---------------------------------------------------");
        System.Console.WriteLine();

        Console.WriteLine("Setting stock to 10:");
        vendingMachine.Stock = 10;

    }
}
