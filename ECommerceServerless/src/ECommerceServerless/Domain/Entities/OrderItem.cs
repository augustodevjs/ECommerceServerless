namespace ECommerceServerless.Domain.Entities;

public class OrderItem
{
    public int Quantity { get; set; }
    public decimal UnitValue { get; set; }
    public int ProductId { get; set; }
}
