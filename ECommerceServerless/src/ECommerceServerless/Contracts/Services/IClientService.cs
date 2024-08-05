using ECommerceServerless.Domain.Entities;

namespace ECommerceServerless.Contracts.Services;

public interface IClientService
{
    Task Add(Client client);
    Task Update(Client client);
    Task Delete(string document);
    Task<Client> Get(string document);
}
