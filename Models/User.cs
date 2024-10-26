using System;
using System.ComponentModel.DataAnnotations;

namespace Eccomerce_Full_Stack.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "User Name")]
    [MinLength(3)]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [Display(Name = "First Name")]
    [MinLength(3)]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [Display(Name = "Last Name")]
    [MinLength(3)]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    [MinLength(8)]
    [MaxLength(100)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required] [DataType(DataType.PhoneNumber)]
    public int phoneNumber { get; set; }

    public string Address { get; set; }
}