namespace CRM.Api.Model;

public class Customer : ITrackedEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public bool IsPotential { get; set; }
    
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }

    public List<PricingAgreement> PricingAgreements { get; set; }
}