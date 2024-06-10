// using System;

// public class VendingMachine
// {
//     public int Stock { get; private set; }
//     public Manager Manager { get; set; }
//     public Customer Customer { get; set; }

//     public void SetStock(int newStock)
//     {
//         Stock = newStock;
//         Notify();
//     }

//     private void Notify()
//     {
//         string status = Stock > 0 ? "Restocked" : "Out of Stock";
        
//         // Memberitahu manager jika sudah terdaftar
//         if (Manager != null)
//         {
//             Manager.OnStockChanged(status);
//         }

//         // Memberitahu customer jika sudah terdaftar
//         if (Customer != null)
//         {
//             Customer.OnStockChanged(status);
//         }
//     }
// }
