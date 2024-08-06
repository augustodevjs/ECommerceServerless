using System.Text.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using ApproveOrderLambda.Injection;
using ECommerceLambda.Domain.Entities;
using ApproveOrderLambda.Contracts.Service;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApproveOrderLambda;

public class Function
{
    private readonly IOrderApproveService _service;

    public Function()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDependecies();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        _service = serviceProvider.GetRequiredService<IOrderApproveService>();
    }

    public async Task Handler(SQSEvent input, ILambdaContext context)
    {
        foreach(var message in input.Records)
        {
            await ProcessMessage(message, context);
        }
    }

    private async Task ProcessMessage(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.Log("Message Serialized.");
        context.Logger.Log(JsonSerializer.Serialize(message));

        context.Logger.Log("ApproximateReceiveCount");
        context.Logger.Log(message.Attributes["ApproximateReceiveCount"]);

        context.Logger.Log("The message has been processed.");
        context.Logger.Log(message.Body);

        var order = JsonSerializer.Deserialize<Order>(message.Body);

        await _service.OrderApprove(order);

        await Task.CompletedTask;
    }
}
