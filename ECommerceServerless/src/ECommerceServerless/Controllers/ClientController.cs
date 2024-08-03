using Microsoft.AspNetCore.Mvc;
using ECommerceServerless.Entities;
using ECommerceServerless.Contracts;

namespace ECommerceServerless.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _repository;

    public ClientController(IClientRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetClient(string document)
    {
        var client = await _repository.Get(document);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(Client client)
    {
        await _repository.Add(client);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClient(Client client)
    {
        await _repository.Update(client);
        return Ok();
    }

    [HttpDelete("{document}")]
    public async Task<IActionResult> DeleteClient(string document)
    {
        await _repository.Delete(document);
        return Ok();
    }
}
