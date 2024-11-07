using System.ComponentModel.DataAnnotations.Schema;

namespace Eccomerce_Full_Stack.Models;

public class StoreDetail
{
    public int Id { get; set; }
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }
    public string StoreImage { get; set; }
    [NotMapped]
    public IFormFile StoreImageFile { get; set; }
}