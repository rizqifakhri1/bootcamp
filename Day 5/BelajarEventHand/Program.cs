using System;

public delegate void PriceChangedEventHandler(object sender, PriceChangedEventArgs e);

public class PriceChangedEventArgs : EventArgs
{
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
}

public class Product
{
    private decimal price;

    public event PriceChangedEventHandler PriceChanged;

    public decimal Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                PriceChangedEventArgs args = new PriceChangedEventArgs
                {
                    OldPrice = price,
                    NewPrice = value
                };

                price = value;
                OnPriceChanged(args);
            }
        }
    }

    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        if (PriceChanged != null)
        {
            PriceChanged(this, e);
        }
    }
}

public class Customer
{
    public void HandlePriceChanged(object sender, PriceChangedEventArgs e)
    {
        Console.WriteLine($"Old price: {e.OldPrice:C}");
        Console.WriteLine($"New price: {e.NewPrice:C}");
    }
}

public static class Program
{
    public static void Main()
    {
        Product product = new Product();
        Customer customer = new Customer();

        product.PriceChanged += customer.HandlePriceChanged;

        Console.WriteLine("Enter a new price:");
        string input = Console.ReadLine();
        decimal newPrice = decimal.Parse(input);
        product.Price = newPrice;
    }
}
