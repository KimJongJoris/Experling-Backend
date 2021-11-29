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
    public class BandTests
    {
        public Mock<IBandRepository> _BandInterfaceMock;

        public BandTests()
        {
            _BandInterfaceMock= new Mock<IBandRepository>();
        }
        
        [Fact]
        public async void Get_Band_From_Id()
        {
            Faker<BandModel> faker = new Faker<BandModel>();
            faker.RuleFor(b => b.id, F => F.UniqueIndex);
            faker.RuleFor(b => b.BandName, F => F.Company.CompanyName());
            faker.RuleFor(b => b.Description, F => F.Person.Email);

            BandModel band = faker.Generate();

            _BandInterfaceMock.Setup(b => b.GetBandById(band.id)).Returns(Task.FromResult(band));

            BandLogic bandLogic = new BandLogic(_BandInterfaceMock.Object);

            var result = bandLogic.GetBandById(band.id);

            Assert.IsType(typeof(Task<BandModel>), result);
        }



    }
}
