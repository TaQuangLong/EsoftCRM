using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Model;

public class CrmDbContext: DbContext
{
    public CrmDbContext(DbContextOptions<CrmDbContext> options): base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<PricingAgreement> PricingAgreements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PricingAgreement>()
            .HasOne(p => p.Product)
            .WithMany(x => x.PricingAgreements)
            .HasForeignKey(x => x.ProductId);
        
        modelBuilder.Entity<PricingAgreement>()
            .HasOne(p => p.Customer)
            .WithMany(x => x.PricingAgreements)
            .HasForeignKey(x => x.CustomerId);
        
        modelBuilder.Entity<Customer>().HasIndex(c => c.Email);
        
        modelBuilder.Entity<PricingAgreement>()
            .HasIndex(pa => pa.CustomerId); 

        modelBuilder.Entity<PricingAgreement>()
            .HasIndex(pa => pa.ProductId); 
        
        modelBuilder.Entity<PricingAgreement>().HasIndex(p => new { p.CustomerId, p.ProductId });
    }

    public override Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<ITrackedEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = now;
                    entry.Entity.DateModified = now;
                    break;
                
                case EntityState.Modified:
                    entry.Entity.DateModified = now;
                    break;
            }
        }

        return base.SaveChangesAsync(token);
    }
}