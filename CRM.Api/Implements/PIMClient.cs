
using Common;
using Common.Config;
using CRM.Api.Dtos;
using Flurl.Http;

namespace CRM.Api.CQRS;

public class PIMClient: IPIMClient
{
    public async Task<ProductDtos> GetProductsAndPrices()
    {
        try
        {
            var url = AppSettings.CrmApi.PIMUrl;
            var resFlurl = await url.GetJsonAsync<ProductDtos>();

            return resFlurl;
        }
        catch (Exception ex)
        {
            throw Exceptions.GetProductAndPricesFromPIMFailed;
        }
        
    }
}