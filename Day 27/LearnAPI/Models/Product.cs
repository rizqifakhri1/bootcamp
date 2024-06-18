using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public string Description { get; set; }

    public int CategoryID { get; set; }

    public int? Price { get; set; }

    public Category Category { get; set; }

}