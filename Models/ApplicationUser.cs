using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Eccomerce_Full_Stack.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? CadrNumber { get; set; }

        public DateTime? ExpireDate { get; set; }

        [MaxLength(3)]
        public string? Cvv { get; set; }
    }
}