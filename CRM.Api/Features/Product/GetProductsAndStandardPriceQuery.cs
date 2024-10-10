using CRM.Api.CQRS;
using CRM.Api.Dtos;
using MediatR;

namespace CRM.Api.Features.Product;

public class GetProductsAndStandardPriceQuery: IRequest<ProductDtos>
{
    public class Handler: IRequestHandler<GetProductsAndStandardPriceQuery, ProductDtos>
    {
        private readonly IPIMClient _pimClient;

        public Handler(IPIMClient pimClient)
        {
            _pimClient = pimClient;
        }

        public async Task<ProductDtos> Handle(GetProductsAndStandardPriceQuery request, CancellationToken cancellationToken)
        {
            var res = await _pimClient.GetProductsAndPrices();

            return res;
        }
    }
}