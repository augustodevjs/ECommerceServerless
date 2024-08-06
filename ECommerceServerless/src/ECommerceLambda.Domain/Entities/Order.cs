using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Converter;
using ECommerceLambda.Domain.Enums;

namespace ECommerceLambda.Domain.Entities;

public class Order
{
    [DynamoDBHashKey(typeof(DynamoDBStringConverter<StatusOrderEnum>))]
    public StatusOrderEnum StatusOrder { get; set; }
    public Guid OrderId { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> OrderItem { get; set; }
    public string DocumentClient
    {
        get
        {
            return Client.Document;
        }
        private set
        {
            DocumentClient = value;
        }
    }

    public decimal TotalValue
    {
        get
        {
            return OrderItem.Sum(x => x.UnitValue * x.Quantity);
        }
        private set
        {
            TotalValue = value;
        }
    }
}
