using System.ComponentModel.DataAnnotations.Schema;

public class Media
{
    public int MediaID { get; set; }

    public int? ProductID { get; set; }

    public string URL { get; set; }

    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
}
