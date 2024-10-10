namespace CRM.Api.Messages;

public class PricingAgreementCreatedMessage: MessageBase
{
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
}