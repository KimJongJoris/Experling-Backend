using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;
using DataAccess.Data;
using DataAccess.Repository;
using Moq;
using Xunit;
using Experling_API.Repository;
using Microsoft.EntityFrameworkCore;
using Logic;

namespace UnitTesting
{
    public class UnitTest1
    {
        public Mock<IBandRepository> _BandInterfaceMock;

        public UnitTest1()
        {
            _BandInterfaceMock= new Mock<IBandRepository>();
        }

        [Fact]
        public async void Test1()
        {
            Faker<BandModel> faker = new Faker<BandModel>();
            faker.RuleFor(b => b.id, F => F.UniqueIndex);
            faker.RuleFor(b => b.BandName, F => F.Company.CompanyName());
            faker.RuleFor(b => b.Description, F => F.Person.Email);

            BandModel band = faker.Generate();

            _BandInterfaceMock.Setup(b => b.GetBandById(band.id)).Returns(Task.FromResult(band));

            BandLogic bandLogic = new BandLogic(_BandInterfaceMock.Object);

            var result = bandLogic.GetBandById(band.id);

            Assert.IsType(typeof(BandModel), result);


        }
    }
}
