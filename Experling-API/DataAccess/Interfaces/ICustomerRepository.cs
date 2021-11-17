using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
         public interface ICustomerRepository

        {
            Task<IEnumerable<CustomerModel>> GetCustomers();
            Task<CustomerModel> GetCustomerById(int id);
            Task<CustomerModel> AddCustomer (CustomerModel Customer);
            Task<CustomerModel> UpdateCustomer (CustomerModel Customer);
            void DeleteCustomer(int id);
        }
    }

