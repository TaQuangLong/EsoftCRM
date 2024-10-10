namespace CRM.Api.Dtos;

[Serializable]
public class ProductDtos
{
    public List<ProductDto> Products;
}

[Serializable]
public class ProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
}