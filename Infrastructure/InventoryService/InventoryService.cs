using Application.Interfaces;
using Infrastructure.Network;

namespace Infrastructure.InventoryService;

public class InventoryService : IInventoryService
{
    private const string AddressTemplate = "http://abc123.com/inventory/products/{0}/notifysaleoccured/";
    private const string JsonTemplate = "{{\"quantity\": {0}}}";

    private readonly IWebClientWrapper _client;

    public InventoryService(IWebClientWrapper client)
    {
        _client = client;
    }

    public void NotifySaleOcurred(int productId, int quantity)
    {
        var address = string.Format(AddressTemplate, productId);
        var json = string.Format(JsonTemplate, quantity);

        Console.WriteLine($"The product with id:{productId} was sold {quantity} times");
        
        _client.Post(address, json);
    }
}