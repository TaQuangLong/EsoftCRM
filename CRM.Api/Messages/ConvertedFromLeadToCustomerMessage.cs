namespace CRM.Api.Messages;

public class ConvertedFromLeadToCustomerMessage: MessageBase
{
    public string CustomerId { get; set; }
    public string Email { get; set; }
}