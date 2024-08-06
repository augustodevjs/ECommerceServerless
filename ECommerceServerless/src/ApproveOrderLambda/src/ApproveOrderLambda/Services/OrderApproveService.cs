using ECommerceLambda.Domain.Entities;
using ApproveOrderLambda.Contracts.Service;
using ApproveOrderLambda.Contracts.Repository;

namespace ApproveOrderLambda.Service;

public class OrderApproveService : IOrderApproveService
{
    private readonly IOrderRepository _repository;

    public OrderApproveService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task OrderApprove(Order order)
    {
        await _repository.SaveOrder(order);
    }
}
