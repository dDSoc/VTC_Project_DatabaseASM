using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    public int OrderID { get; set; }

    public int? CustomerID { get; set; }

    public int? CustomerAddressID { get; set; }

    [ForeignKey("CustomerID")]
    public virtual Customers Customer { get; set; }

    [ForeignKey("CustomerAddressID")]
    public virtual CustomerAddress CustomerAddress { get; set; }
}
