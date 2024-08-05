﻿using Amazon.SQS;
using System.Text.Json;
using Amazon.SQS.Model;
using ECommerceServerless.Domain.Entities;
using ECommerceServerless.Contracts.Services;

namespace ECommerceServerless.Services;

public class OrderService : IOrderService
{
    private readonly IAmazonSQS _sqsClient;

    public OrderService(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }

    public async Task SendOrder(Order order)
    {
        var request = new SendMessageRequest
        {
            MessageBody = JsonSerializer.Serialize(order),
            QueueUrl = Environment.GetEnvironmentVariable("ORDER_CREATED_SQS_URL")
        };

        await _sqsClient.SendMessageAsync(request);
    }
}
