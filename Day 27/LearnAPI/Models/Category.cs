using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

public class Category
{
    [Key]
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }
    [Column(TypeName = "TEXT")]
    public string Description { get; set; }
    public IEnumerable<Product> Products { get; set; }

    public Category()
    {
        Products = new List<Product>();
    }
}