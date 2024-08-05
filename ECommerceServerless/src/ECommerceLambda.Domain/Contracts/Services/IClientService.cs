using ECommerceLambda.Domain.Entities;

namespace ECommerceLambda.Domain.Contracts.Services;

public interface IClientService
{
    Task Add(Client client);
    Task Update(Client client);
    Task Delete(string document);
    Task<Client> Get(string document);
}
