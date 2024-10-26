namespace Eccomerce_Full_Stack.Models;

public class CartItem
{
    public Guid ProductId { get; set; }
    public required string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Image { get; set; }
}