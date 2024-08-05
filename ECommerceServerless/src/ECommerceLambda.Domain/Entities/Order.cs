using ECommerceLambda.Domain.Enums;

namespace ECommerceLambda.Domain.Entities;

public class Order
{
    public StatusOrderEnum StatusOrder { get; set; }
    public Guid OrderId { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> OrderItem { get; set; }
    public string DocumentClient => Client.Document;
    public decimal TotalValue => OrderItem.Sum(x => x.UnitValue * x.Quantity);
}
