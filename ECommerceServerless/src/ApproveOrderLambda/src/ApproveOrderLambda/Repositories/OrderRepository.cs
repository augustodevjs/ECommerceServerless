using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Entities;
using ApproveOrderLambda.Contracts.Repository;

namespace ApproveOrderLambda.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IDynamoDBContext _context;

    public OrderRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task SaveOrder(Order order)
    {
        await _context.SaveAsync(order);
    }
}
