using ECommerceServerless.Domain.Enums;

namespace ECommerceServerless.Domain.Entities;

public class Order
{
    public StatusOrderEnum StatusOrder { get; set; }
    public string DocumentClient => Client.Document;
    public Guid OrderId { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> OrderItem { get; set; }
    public decimal TotalValue => OrderItem.Sum(x => x.UnitValue * x.Quantity);
}
