using ApproveOrderLambda.Service;
using ApproveOrderLambda.Repository;
using ApproveOrderLambda.Contracts.Service;
using ApproveOrderLambda.Contracts.Repository;
using Microsoft.Extensions.DependencyInjection;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.SQS;

namespace ApproveOrderLambda.Injection;

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
        services.AddScoped<IOrderApproveService, OrderApproveService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void AddAmazonDependecies(this IServiceCollection services)
    {
        services.AddScoped<IDynamoDBContext, DynamoDBContext>();
        services.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
    }
}