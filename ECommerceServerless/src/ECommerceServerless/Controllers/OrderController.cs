﻿using Microsoft.AspNetCore.Mvc;
using ECommerceServerless.Domain.Entities;
using ECommerceServerless.Contracts.Services;

namespace ECommerceServerless.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        IOrderService service, 
        ILogger<OrderController> logger
    )
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(Order order)
    {
        _logger.LogInformation("Sending order to SQS queue.");

        await _service.SendOrder(order);

        return Ok();
    }

}
