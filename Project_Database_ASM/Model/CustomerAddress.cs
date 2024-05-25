using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomerAddress
{
    [Key]
    public int CustomerAddressID { get; set; }

    public int? CustomerID { get; set; }

    public int? AddressID { get; set; }

    public string? AddressName { get; set; }

    [ForeignKey("CustomerID")]
    public virtual Customers Customer { get; set; }

}
