namespace Common.Config;

public static class Exceptions
{
    public static DomainException CustomerDoesNotExist = new DomainException("Customer does not exist");
    public static DomainException GetProductAndPricesFromPIMFailed = new DomainException("Get products and prices from PIM failed");
}