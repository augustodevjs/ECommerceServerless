using ECommerceLambda.Domain.Entities;

namespace ApproveOrderLambda.Contracts.Repository;

public interface IOrderRepository
{
    Task SaveOrder(Order order);
}
