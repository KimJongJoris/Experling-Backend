using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;

namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;

        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }
        
        [HttpGet]
         public async Task<ActionResult> GetCustomers()
         {
             return Ok(await customerLogic.GetAllCustomer());
         }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerById(int id)
        {
            var result = await customerLogic.GetCustomerById(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> CreateCustomer(CustomerModel Customer)
        {
            var createdCustomer = await customerLogic.AddCustomer(Customer);

            return CreatedAtAction(nameof(GetCustomerById),
                new { id = createdCustomer.id }, createdCustomer);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(int id, CustomerModel customer)
        {
            if (id != customer.id)
                return BadRequest("Customer Id doesn't match!");

            var customerToUpdate = await customerLogic.GetCustomerById(id);

            if (customerToUpdate == null)
                return NotFound();

            return await customerLogic.UpdateCustomer(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomer(int id)
        {
            var customerToDelete = await customerLogic.GetCustomerById(id);
            if (customerToDelete == null)
            {
                    return NotFound();
            }

            return await customerLogic.DeleteCustomer(id); 
        }

    }
}
