using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_Full_Stack.Models;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }
    [MaxLength(500)]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
    public string? StoreId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Image { get; set; }
    public Category? Category { get; set; }

}