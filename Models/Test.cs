using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Eccomerce_Full_Stack.Models;

public class Test
{
    [Key]
    public Guid ProductId { get; set; }

    public string  yoyo { get; set; }
}