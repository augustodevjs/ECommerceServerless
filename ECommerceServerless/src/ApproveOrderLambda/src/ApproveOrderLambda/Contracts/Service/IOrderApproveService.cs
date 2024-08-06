using ECommerceLambda.Domain.Entities;

namespace ApproveOrderLambda.Contracts.Service;

public interface IOrderApproveService
{
    Task OrderApprove(Order order);
}
