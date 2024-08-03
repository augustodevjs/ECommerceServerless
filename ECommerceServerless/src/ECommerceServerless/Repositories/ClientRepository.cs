﻿using Amazon.DynamoDBv2.DataModel;
using ECommerceServerless.Entities;
using ECommerceServerless.Contracts;

namespace ECommerceServerless.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDynamoDBContext _context;

    public ClientRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task Add(Client client)
    {
        await _context.SaveAsync<Client>(client);
    }

    public async Task Delete(string document)
    {
        await _context.DeleteAsync<Client>(document);
    }

    public async Task<Client> Get(string document)
    {
        return await _context.LoadAsync<Client>(document);
    }

    public async Task Update(Client client)
    {
        await _context.SaveAsync<Client>(client);
    }
}
