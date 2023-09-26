using Clientes.Model;
using Core.Entities;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : CustomController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// Returns all the customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list of customers.");
                return BadRequest("No se pudo encontrar el cliente. Inténtelo más tarde.");
            }
        }

        /// <summary>
        /// Return the customer for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting customer by id: {id}");
                return BadRequest(new { error = "No se encontró el cliente. Inténtelo más tarde." });
            }
        }

        [HttpGet(nameof(Search))]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var customers = await _customerService.SearchByNameAsync(name);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error searching customer by name: {name}");
                return BadRequest(new { error = "No se pudo procesar la búsqueda. Inténtelo más tarde." });
            }
        }

        /// <summary>
        /// Creates a new customer with the given data
        /// </summary>
        /// <param name="customerRequestModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel customerRequestModel)
        {
            try
            {
                var customer = MapTo<CustomerRequestModel, Customer>(customerRequestModel);
                customer = await _customerService.CreateAsync(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating customer: {customerRequestModel}");
                return BadRequest(new { error = "No se pudo crear el cliente. Inténtelo más tarde." });
            }
        }

        /// <summary>
        /// Updates a customer with the given data
        /// </summary>
        /// <param name="customerRequestModel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerRequestModel customerRequestModel)
        {
            try
            {
                var customer = MapTo<CustomerRequestModel, Customer>(customerRequestModel);
                customer = await _customerService.Update(customer);
                return Ok(customer);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { validation = ex.Errors.Select(x => x.ErrorMessage).ToArray() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating customer: {customerRequestModel}");
                return BadRequest(new { error = "No se pudo actualizar el cliente. Inténtelo más tarde." });
            }
        }
    }
}
