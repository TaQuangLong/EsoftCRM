namespace CRM.Api.Messages;

public class PricingAgreementActivatedMessage: MessageBase
{
    public string AgreementId { get; set; }
}