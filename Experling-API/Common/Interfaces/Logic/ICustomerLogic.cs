using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Logic
{
    public interface ICustomerLogic
    {
        public Task<IEnumerable<CustomerModel>> GetAllCustomer();
        public Task<CustomerModel> GetCustomerById(int id);
        public Task<CustomerModel> AddCustomer(CustomerModel customer);
        public Task<CustomerModel> UpdateCustomer(CustomerModel customer);
        public Task<CustomerModel> DeleteCustomer(int id);

    }
}
