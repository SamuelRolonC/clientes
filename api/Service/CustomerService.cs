using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _customerValidator;

        public CustomerService(ICustomerRepository customerRepository
            , IValidator<Customer> customerValidator)
        {
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> SearchByNameAsync(string name)
        {
            return await _customerRepository.SearchByNameAsync(name);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var result = _customerValidator.Validate(customer);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            customer.CreatedBy = "App";
            customer.CreatedAt = DateTime.Today;
            return await _customerRepository.CreateAsync(customer);
        }

        public async Task<Customer> Update(Customer customer)
        {
            var result = _customerValidator.Validate(customer);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var customerToUpdate = await _customerRepository.GetByIdAsTrackingAsync(customer.Id);
            if (customerToUpdate == null)
                throw new Exception($"Customer with id {customer.Id} not found.");

            customerToUpdate.Name = customer.Name;
            customerToUpdate.Surname = customer.Surname;
            customerToUpdate.Birthdate = customer.Birthdate;
            customerToUpdate.Cuit = customer.Cuit;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.UpdatedBy = "App";
            customerToUpdate.UpdatedAt = DateTime.Today;

            return await _customerRepository.Update(customerToUpdate);
        }
    }
}