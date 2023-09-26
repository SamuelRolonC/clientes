using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByIdAsTrackingAsync(int id);
        Task<IEnumerable<Customer>> SearchByNameAsync(string name);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> Update(Customer customer);
    }
}
