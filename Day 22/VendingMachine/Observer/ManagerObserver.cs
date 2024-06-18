using VendingMachine.Interface;
namespace VendingMachine.Observer;

public class ManagerObserver : IVendingMachineObserver
{
    private string name;

    public ManagerObserver(string name)
    {
        this.name = name;
    }

    public void Update(string status)
    {
        Console.WriteLine($"[ Manager  ] {name} notified: Vending Machine is {status}");
    }
}