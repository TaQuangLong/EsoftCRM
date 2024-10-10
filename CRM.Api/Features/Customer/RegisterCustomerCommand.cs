using CRM.Api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Features.Customer;

public class RegisterCustomerCommand: IRequest
{
    public string Id { get; set; }  
    public string Name { get; set; }  
    public string Email { get; set; }  
    
    public class Handler: IRequestHandler<RegisterCustomerCommand>
    {
        private readonly CrmDbContext _dbContext;

        public Handler(CrmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (customer == default)
            {
                _dbContext.Customers.Add(new Model.Customer()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                });
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}