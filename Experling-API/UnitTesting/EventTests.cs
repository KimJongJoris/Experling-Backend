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
    public class EventTests
    {
        public Mock<IEventRepository> _EventInterfaceMock;

        public EventTests()
        {
            _EventInterfaceMock= new Mock<IEventRepository>();
        }
        
        [Fact]
        public async void Get_Event_From_Id()
        {
            Faker<EventModel> faker = new Faker<EventModel>();
            faker.RuleFor(e => e.id, F => F.UniqueIndex);
            faker.RuleFor(e => e.EventName, F => F.Company.CompanyName());
            faker.RuleFor(e => e.Description, F => F.Person.Email);

            EventModel Event = faker.Generate();

            _EventInterfaceMock.Setup(e => e.GetEventById(Event.id)).Returns(Task.FromResult(Event));

            EventLogic eventLogic = new EventLogic(_EventInterfaceMock.Object);

            var result = eventLogic.GetEventById(Event.id);

            Assert.IsType(typeof(Task<EventModel>), result);
        }



    }
}
