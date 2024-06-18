using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        //Check Connection
        using (Database db = new())
        {
            bool isActive = db.Database.CanConnect();
            System.Console.WriteLine(isActive);
        }

        // Create
        TambahData();

        // Read
        BacaData();

        // Update
        PerbaruiData();
        UpdateData();

        // Delete
        HapusData();
        DeleteCar();

        System.Console.WriteLine();
        System.Console.WriteLine("Setelah Update dan Delete");
        System.Console.WriteLine();

        BacaData();
    }

    // Tambah data biasa tanpa pengecekan

    // private static void TambahData()
    // {
    //     using (var context = new Database())
    //     {
    //         var modelBaru = new Model { ModelName = "Sedan", Description = "Sedan City Car" };
    //         context.Models.Add(modelBaru);

    //          var modelBaru2 = new Model { ModelName = "Motor", Description = "Numpang Masuk" };
    //         context.Models.Add(modelBaru2);

    //         var mobilBaru = new Car { CarName = "Toyota Camry", Model = modelBaru };
    //         context.Cars.Add(mobilBaru);

    //         context.SaveChanges();
    //     }
    // }

    private static void TambahData()
    {
        using (var context = new Database())
        {
            // Nama mobil yang ingin ditambahkan
            string carName = "Toyota Camry";

            // Periksa apakah nama mobil sudah ada di database
            bool carExists = context.Cars.Any(c => c.CarName == carName);
            if (carExists)
            {
                Console.WriteLine($"Nama mobil '{carName}' sudah ada.");
                return; // Keluar dari metode tanpa menambah data
            }

            // Jika nama tidak ada, lanjutkan menambah data
            var modelBaru = new Model { ModelName = "Sedan", Description = "Sedan City Car" };
            context.Models.Add(modelBaru);

            var mobilBaru = new Car { CarName = carName, Model = modelBaru };
            context.Cars.Add(mobilBaru);

            context.SaveChanges();
            Console.WriteLine($"Mobil '{carName}' berhasil ditambahkan.");
        }
    }


    private static void BacaData()
    {
        using (var context = new Database())
        {
            var mobil = context.Cars.Include(c => c.Model).ToList();
            foreach (var car in mobil)
            {
                Console.WriteLine($"Nama Mobil: {car.CarName}, Model: {car.Model.ModelName}");
            }
        }
    }

    // Update Method 1 (tanpa pengecekan)
    // private static void PerbaruiData()
    // {
    //     using (var context = new Database())
    //     {
    //         var updateCar = context.Cars.FirstOrDefault(c => c.CarID == 1);
    //         if (updateCar != null)
    //         {
    //             updateCar.CarName = "Toyota Kijang";
    //             context.SaveChanges();
    //         }
    //     }
    // }

    //Dengan Pengecekan
    private static void PerbaruiData()
    {
        using (var context = new Database())
        {
            // Ambil mobil yang ingin diperbarui
            var updateCar = context.Cars.FirstOrDefault(c => c.CarID == 1);
            if (updateCar != null)
            {
                string newCarName = "Toyota Camry";

                // Periksa apakah nama baru sudah ada di database, kecuali nama yang sama dengan yang sedang diperbarui
                bool nameExists = context.Cars.Any(c => c.CarName == newCarName && c.CarID != updateCar.CarID);
                if (nameExists)
                {
                    Console.WriteLine($"Nama mobil '{newCarName}' sudah ada.");
                    return; // Keluar dari metode tanpa memperbarui data
                }

                // Jika nama baru tidak ada, lanjutkan memperbarui data
                updateCar.CarName = newCarName;
                context.SaveChanges();
                Console.WriteLine($"Mobil dengan ID {updateCar.CarID} berhasil diperbarui ke '{newCarName}'.");
            }
        }
    }


    //Update Method 2
    private static void UpdateData()
    {

        using (var context = new Database())
        {
            Car? car = context.Cars.Find(3);
            if (car != null)
            {
                car.CarName = "Honda Jazz";
                car.ModelID = 10;
                context.SaveChanges();
            }
        }
    }

    private static void HapusData()
    {
        using (var context = new Database())
        {
            var deleteCar = context.Cars.FirstOrDefault(c => c.CarID == 2);
            if (deleteCar != null)
            {
                context.Cars.Remove(deleteCar);
                context.SaveChanges();
            }
        }
    }

    //Update Delete 2
    private static void DeleteCar()
    {

        using (var context = new Database())
        {
            Car? car = context.Cars.Find(3);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }
    }

    // //Delete
    // using (Northwind db = new())
    // {

    //     Product? product = db.Products.Find(77);
    //     db.Products.Remove(product);
    //     db.SaveChanges();
    // }
}