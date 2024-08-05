using ECommerceServerless.Domain.Entities;

namespace ECommerceServerless.Contracts.Services;

public interface IOrderService
{
    Task SendOrder(Order order);
}
