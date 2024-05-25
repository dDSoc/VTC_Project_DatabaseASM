using System.ComponentModel.DataAnnotations;

public class Customers
{
    [Key]
    public int CustomerID { get; set; }

    [Required]
    [StringLength(255)]
    public string FullName { get; set; }

    [Required]
    [StringLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
}
