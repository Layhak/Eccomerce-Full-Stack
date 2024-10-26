using System;
using System.ComponentModel.DataAnnotations;

namespace Eccomerce_Full_Stack.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name = "Category Name")]
    public string? CategoryName { get; set; }
}