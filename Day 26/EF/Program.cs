class Program
{
    static void Main()
    {

        //Read
        using (Northwind db = new())
        {
            bool isActive = db.Database.CanConnect();
            System.Console.WriteLine(isActive);
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                System.Console.WriteLine(category.CategoryName);
            }
        }

        // //Create
        // using (Northwind db = new()) //membuka koneksi ke DB
        // {
        //     Category category = new();
        //     category.CategoryName = "durian";
        //     category.Description = "Enak bet";
        //     //Nambahin Data (tapi belum disave [cuma numpang])
        //     db.Categories.Add(category);
        //     //Save DB
        //     db.SaveChanges();
        // }

        // //Create [AddRange]
        // using (Northwind db = new()) //membuka koneksi ke DB
        // {
        //     Category category = new();
        //     category.CategoryName = "durian";
        //     category.Description = "Enak bet";
        //     //Nambahin Data (tapi belum disave [cuma numpang])
        //     db.Categories.AddRange(category);
        //     //Save DB
        //     db.SaveChanges();
        // }

        // //Create [Multiple Input]
        // using (Northwind db = new()) //membuka koneksi ke DB
        // {
        //     Category category = new();
        //     Category category1 = new Category
        //     {
        //         CategoryName = "Durian",
        //         Description = "Enak banget"
        //     };

        //     Category category2 = new Category
        //     {
        //         CategoryName = "Mangosteen",
        //         Description = "Manis dan asam"
        //     };

        //     Category category3 = new Category
        //     {
        //         CategoryName = "Rambutan",
        //         Description = "Segar dan manis"
        //     };

        //     db.Categories.AddRange(category1, category2, category3);
        //     //Save DB
        //     db.SaveChanges();
        // }

        //Update by Name
        // using (Northwind db = new())
        // {
        //     Category? category = db.Categories.Where(data => data.CategoryName.Contains("durian")).FirstOrDefault();
        //     category.Description = "Durian mahal banget";
        //     db.SaveChanges();
        // }

        // //Update by ID
        // using (Northwind db = new())
        // {
        //     Category? category = db.Categories.Find(9);
        //     category.CategoryName = "Rizqi";
        //     category.Description = "Hahaha";
        //     db.SaveChanges();
        // }

        // //Delete
        // using (Northwind db = new())
        // {
            
        //     Product? product = db.Products.Find(77);
        //     db.Products.Remove(product);
        //     db.SaveChanges();
        // }
    }
    //test test test test
}