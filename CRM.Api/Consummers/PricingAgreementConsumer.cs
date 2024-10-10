using CRM.Api.CQRS;
using CRM.Api.Messages;
using CRM.Api.Model;
using MassTransit;

namespace CRM.Api.Consummers;

public class PricingAgreementConsumer: IConsumer<PricingAgreementCreatedMessage>
{
    private readonly CrmDbContext _dbContext;
    private readonly ICQRSClient _client;

    public PricingAgreementConsumer(CrmDbContext dbContext, ICQRSClient client)
    {
        _dbContext = dbContext;
        _client = client;
    }

    public async Task Consume(ConsumeContext<PricingAgreementCreatedMessage> context)
    {
        var message = context.Message;

        var agreement = new PricingAgreement(message.CustomerId, message.ProductId, message.Price);

        _dbContext.PricingAgreements.Add(agreement);
        
        await _dbContext.SaveChangesAsync();
        
        //publish message to Notification Service
        var msg = new PricingAgreementActivatedMessage()
        {
            AgreementId = agreement.Id
        };

        await _client.PublishAsync(msg);

    }
}