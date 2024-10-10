using CRM.Api.Dtos;

namespace CRM.Api.CQRS;

public interface IPIMClient
{
    Task<ProductDtos> GetProductsAndPrices();
}