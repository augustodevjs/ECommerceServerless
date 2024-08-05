using Amazon.SQS;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ECommerceServerless.Services;
using ECommerceServerless.Repositories;
using ECommerceLambda.Domain.Contracts.Services;
using ECommerceLambda.Domain.Contracts.Repository;

namespace ECommerceServerless.Injection;

public static class DependecyInjection
{
    public static void AddDependecies(this IServiceCollection services)
    {
        services.AddServices();
        services.AddRepositories();
        services.AddAmazonDependecies();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IClientService, ClientService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
    }

    public static void AddAmazonDependecies(this IServiceCollection services)
    {
        services.AddScoped<IAmazonSQS, AmazonSQSClient>();
        services.AddScoped<IDynamoDBContext, DynamoDBContext>();
        services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
        services.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
    }
}
