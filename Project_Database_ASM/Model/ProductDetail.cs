using System.ComponentModel.DataAnnotations.Schema;

public class ProductDetail
{
    public int ProductDetailID { get; set; }

    public int? ProductID { get; set; }

    public int? ColorID { get; set; }

    public int? SizeID { get; set; }

    public int Quantity { get; set; }

    public decimal? Price { get; set; }

    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }

    [ForeignKey("ColorID")]
    public virtual Color Color { get; set; }

    [ForeignKey("SizeID")]
    public virtual Size Size { get; set; }
}
