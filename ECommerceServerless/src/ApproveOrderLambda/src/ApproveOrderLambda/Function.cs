using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApproveOrderLambda;

public class Function
{
    public async Task Handler(SQSEvent input, ILambdaContext context)
    {
        foreach(var message in input.Records)
        {
            await ProcessMessage(message, context);
        }
    }

    private async Task ProcessMessage(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.Log("The message has been processed.");
        context.Logger.Log(message.Body);

        await Task.CompletedTask;
    }
}
