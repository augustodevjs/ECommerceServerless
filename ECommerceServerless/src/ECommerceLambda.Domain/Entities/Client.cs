using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Domain.Entities;

[DynamoDBTable("Client")]
public class Client
{
    [DynamoDBHashKey("Document")]
    public string Document { get; set; }

    [DynamoDBProperty]
    public string Name { get; set; }

    [DynamoDBProperty]
    public string Email { get; set; }

    [DynamoDBProperty]
    public Address Address { get; set; }
}
