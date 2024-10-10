using Common.Config;
using CRM.Api.CQRS;
using CRM.Api.Messages;
using CRM.Api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Features.Customer;

public class ConvertedFromLeadToCustomerCommand : IRequest
{
    public string CustomerId { get; set; }

    public class Handler : IRequestHandler<ConvertedFromLeadToCustomerCommand>
    {
        private readonly CrmDbContext _dbContext;

        private readonly ICQRSClient _client;

        public Handler(CrmDbContext dbContext, ICQRSClient client)
        {
            _dbContext = dbContext;
            _client = client;
        }

        public async Task Handle(ConvertedFromLeadToCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync
                                        (c => c.Id == request.CustomerId);

                if (customer == default)
                {
                    throw Exceptions.CustomerDoesNotExist;
                }

                customer.IsPotential = true;

                //send event changed to services Potential Customer
                var message = new ConvertedFromLeadToCustomerMessage()
                {
                    CustomerId = customer.Id,
                    Email = customer.Email,
                };
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                await _client.PublishAsync(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}