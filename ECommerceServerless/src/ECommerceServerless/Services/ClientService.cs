﻿using ECommerceLambda.Domain.Entities;
using ECommerceLambda.Domain.Contracts.Services;
using ECommerceLambda.Domain.Contracts.Repository;

namespace ECommerceServerless.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task Add(Client client)
    {
        await _repository.Add(client);
    }

    public Task Delete(string document)
    {
        return _repository.Delete(document);
    }

    public async Task<Client> Get(string document)
    {
        var client = await _repository.Get(document);

        return client;
    }

    public Task Update(Client client)
    {
        return _repository.Update(client);
    }
}
