namespace CRM.Api.Model;

public class Product
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string BasePrice { get; set; }

    public List<PricingAgreement> PricingAgreements { get; set; }
}