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
    public class TicketTests
    {
        public Mock<ITicketRepository> _TicketInterfaceMock;

        public TicketTests()
        {
            _TicketInterfaceMock= new Mock<ITicketRepository>();
        }
        
        [Fact]
        public async void Get_Ticket_From_Id()
        {
            Faker<TicketModel> faker = new Faker<TicketModel>();
            faker.RuleFor(t => t.id, F => F.UniqueIndex);
            faker.RuleFor(t => t.CustomerName, F => F.Company.CompanyName());
            faker.RuleFor(t => t.CustomerEmail, F => F.Person.Email);

            TicketModel ticket = faker.Generate();

            _TicketInterfaceMock.Setup(e => e.GetTicketById(ticket.id)).Returns(Task.FromResult(ticket));

            TicketLogic ticketLogic = new TicketLogic(_TicketInterfaceMock.Object);

            var result = ticketLogic.GetTicketById(ticket.id);

            Assert.IsType(typeof(Task<TicketModel>), result);
        }



    }
}
