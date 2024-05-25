using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public int? CategoryID { get; set; }

    [ForeignKey("CategoryID")]
    public virtual Category Category { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }

}
