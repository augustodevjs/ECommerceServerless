using ECommerceServerless.Domain.Entities;

namespace ECommerceServerless.Contracts.Repository;

public interface IClientRepository
{
    Task Add(Client client);
    Task Update(Client client);
    Task Delete(string document);
    Task<Client> Get(string document);
}
