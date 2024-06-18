using VendingMachine.Interface;
namespace VendingMachine.Observer;

public class CustomerObserver : IVendingMachineObserver
{
    private string name;

    public CustomerObserver(string name)
    {
        this.name = name;
    }

    public void Update(string status)
    {
        Console.WriteLine($"[ Customer ] {name} notified: Vending Machine is {status}");
    }
}