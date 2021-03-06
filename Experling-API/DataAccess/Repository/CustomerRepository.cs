using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Experling_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        { 
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            return await Task.FromResult(_appDbContext.Customers.Find(id));
        }

        public async Task<CustomerModel> AddCustomer(CustomerModel Customer)
        {
            var result = await _appDbContext.Customers.AddAsync(Customer);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CustomerModel> UpdateCustomer(CustomerModel Customer)
        {
            var result = await _appDbContext.Customers.FirstOrDefaultAsync(e => e.id == Customer.id);

            if (result != null)
            {
                result.Name = Customer.Name;
                result.Email = Customer.Email;

                await _appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<CustomerModel> DeleteCustomer(int CustomerId)
        {
            var result = await _appDbContext.Customers.FirstOrDefaultAsync(e => e.id == CustomerId);
            if (result != null)
            {
                _appDbContext.Customers.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }



    }
}
