using CRM.Api.Messages;

namespace CRM.Api.CQRS;

public interface ICQRSClient
{
    Task PublishAsync<T>(T message) where T: MessageBase;
}