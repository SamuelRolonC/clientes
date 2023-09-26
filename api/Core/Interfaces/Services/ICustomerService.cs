using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> SearchByNameAsync(string name);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> Update(Customer customer);
    }
}
