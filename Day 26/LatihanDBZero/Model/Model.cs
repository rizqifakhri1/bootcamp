// namespace LatihanDBZero.Model;

using System.ComponentModel.DataAnnotations.Schema;

public class Model
{
    public int ModelID { get; set; }
    public string ModelName { get; set; }

    [Column(TypeName = "TEXT")]
    public string Description { get; set; }

    public IEnumerable<Car> Cars { get; set; }
}
