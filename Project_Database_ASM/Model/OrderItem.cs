using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    public int OrderItemID { get; set; }

    public int? OrderID { get; set; }

    public int? ProductDetailID { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("OrderID")]
    public virtual Order Order { get; set; }

    [ForeignKey("ProductDetailID")]
    public virtual ProductDetail ProductDetail { get; set; }
}
