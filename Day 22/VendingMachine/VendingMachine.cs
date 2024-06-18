using VendingMachine.Interface;
namespace VendingMachine;

// Subjek atau sebagai Publisher

public class VendingMachine
{
    private List<IVendingMachineObserver> observers = new List<IVendingMachineObserver>();
    private int stock;

    //Mengubah stok
    public int Stock
    {
        get { return stock; }
        set
        {
            stock = value;
            Notify(); // Ketika stok berubah, semua pengamat diberitahu
        }
    }

    //Menambah pengamat (Observer)
    public void Attach(IVendingMachineObserver observer)
    {
        observers.Add(observer);
    }

    //Menghapus pengamat (Observer)
    public void Detach(IVendingMachineObserver observer)
    {
        observers.Remove(observer);
    }

    //Memberitahu semua pengamat (Observer)
    public void Notify()
    {
        string status = stock > 0 ? $"Restocked {stock}" : "Out of Stock";
        foreach (IVendingMachineObserver observer in observers)
        {
            observer.Update(status);
        }
    }
}
