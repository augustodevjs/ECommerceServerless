using ECommerceLambda.Domain.Entities;

namespace ECommerceLambda.Domain.Contracts.Services;

public interface IOrderService
{
    Task SendOrder(Order order);
}
