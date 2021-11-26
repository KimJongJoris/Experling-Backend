using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Data
{
         public interface ICustomerRepository

        {
            Task<IEnumerable<CustomerModel>> GetCustomers();
            Task<CustomerModel> GetCustomerById(int id);
            Task<CustomerModel> AddCustomer (CustomerModel Customer);
            Task<CustomerModel> UpdateCustomer (CustomerModel Customer);
            Task<CustomerModel> DeleteCustomer(int id);
        }
    }

