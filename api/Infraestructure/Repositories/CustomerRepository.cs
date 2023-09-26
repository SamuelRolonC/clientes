using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                using var context = new CustomerContext();
                return await context.Customers.OrderBy(x => x.Surname).ThenBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list of customers.");
                return new List<Customer>();
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                using var context = new CustomerContext();
                return await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting customer by id: {id}");
                return new Customer();
            }
        }

        public async Task<Customer> GetByIdAsTrackingAsync(int id)
        {
            try
            {
                using var context = new CustomerContext();
                return await context.Customers.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting customer by id: {id}");
                return new Customer();
            }
        }

        public async Task<IEnumerable<Customer>> SearchByNameAsync(string name)
        {
            try
            {
                using var context = new CustomerContext();
                return await context.Customers.Where(x => x.Name.Contains(name) || x.Surname.Contains(name)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting customer by name: {name}");
                return new List<Customer>();
            }
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                using var context = new CustomerContext();
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating customer: {customer}");
                return new Customer();
            }
        }

        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                using var context = new CustomerContext();
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating customer: {customer}");
                return new Customer();
            }
        }
    }
}
