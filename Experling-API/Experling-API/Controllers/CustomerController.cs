using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        
        [HttpGet]
         public async Task<ActionResult> GetCustomers()
        {
            return Ok(await customerRepository.GetCustomers());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerById(int id)
        {
            var result = await customerRepository.GetCustomerById(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> CreateCustomer(CustomerModel Customer)
        {
            var createdCustomer = await customerRepository.AddCustomer(Customer);

            return CreatedAtAction(nameof(GetCustomerById),
                new { id = createdCustomer.id }, createdCustomer);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(int id, CustomerModel customer)
        {
            if (id != customer.id)
                return BadRequest("Customer Id doesn't match!");

            var customerToUpdate = await customerRepository.GetCustomerById(id);

            if (customerToUpdate == null)
                return NotFound();

            return await customerRepository.UpdateCustomer(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomer(int id)
        {
            var customerToDelete = await customerRepository.GetCustomerById(id);
            if (customerToDelete == null)
            {
                    return NotFound();
            }

            return await customerRepository.DeleteCustomer(id); 
        }

    }
}
