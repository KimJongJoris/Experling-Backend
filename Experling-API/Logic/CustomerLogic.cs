using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;

namespace Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository _customerRepository;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerModel>> GetAllCustomer()
        {
            return _customerRepository.GetCustomers();
        }

        public Task<CustomerModel> GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public Task<CustomerModel> AddCustomer(CustomerModel customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public Task<CustomerModel> UpdateCustomer(CustomerModel customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public Task<CustomerModel> DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

    }
}
