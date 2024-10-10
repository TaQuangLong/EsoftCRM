using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Api.Model;

public class PricingAgreement: ITrackedEntity
{
    public string Id { get; set; }
    public string CustomerId  { get; set; }
    public string ProductId  { get; set; }
    public decimal Price  { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }

    public Product Product { get; set; }
    public Customer Customer { get; set; }

    public PricingAgreement(string customerId, string productId, decimal price)
    {
        Id = Guid.NewGuid().ToString();
        CustomerId = customerId;
        ProductId = productId;
        Price = price;
        DateCreated = DateTime.UtcNow;
    }

    public class Configuration : IEntityTypeConfiguration<PricingAgreement>
    {
        public void Configure(EntityTypeBuilder<PricingAgreement> builder)
        {
           
        }                                                                                   
    }
}                                                       