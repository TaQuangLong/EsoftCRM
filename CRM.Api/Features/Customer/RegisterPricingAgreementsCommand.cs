using MediatR;

namespace CRM.Api.Features.Customer;

public class RegisterPricingAgreementsCommand: IRequest
{
    public class Handler : IRequestHandler<RegisterPricingAgreementsCommand>
    {
        public Task Handle(RegisterPricingAgreementsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}