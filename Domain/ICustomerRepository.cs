namespace MortgageService.Domain
{
    public interface ICustomerRepository
    {
        Customer Get(int customerId);
    }
}
