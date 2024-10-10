using CRM.Api.Messages;
using MassTransit;

namespace CRM.Api.CQRS;

public class CQRSClient: ICQRSClient
{
    private readonly IBus _bus;

    public CQRSClient(IBus bus)
    {
        _bus = bus;
    }

    public async Task PublishAsync<T>(T message) where T : MessageBase
    {
        await _bus.Publish(message);
    }
}