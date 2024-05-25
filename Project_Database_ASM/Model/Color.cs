using System.ComponentModel.DataAnnotations;

public class Color
{
    [Key]
    public int ColorID { get; set; }

    [Required]
    [StringLength(255)]
    public string ColorName { get; set; }
}
