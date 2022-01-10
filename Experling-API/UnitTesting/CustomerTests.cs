using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;
using Experling_API.Controllers;
using Moq;
using Xunit;
using Logic;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting
{
    public class CustomerTests
    {
        public Mock<ICustomerRepository> _CustomerInterfaceMock;

        public CustomerTests()
        {
            _CustomerInterfaceMock= new Mock<ICustomerRepository>();
        }
        
        [Fact]
        public async void Get_Customer_From_Id()
        {
            Faker<CustomerModel> faker = new Faker<CustomerModel>();
            faker.RuleFor(c => c.id, F => F.UniqueIndex);
            faker.RuleFor(c => c.Name, F => F.Company.CompanyName());
            faker.RuleFor(c => c.Email, F => F.Person.Email);

            CustomerModel customer = faker.Generate();

            _CustomerInterfaceMock.Setup(b => b.GetCustomerById(customer.id)).Returns(Task.FromResult(customer));

            CustomerLogic customerLogic = new CustomerLogic(_CustomerInterfaceMock.Object);

            var result = customerLogic.GetCustomerById(customer.id);

            Assert.IsType(typeof(Task), result);
        }



    }
}
