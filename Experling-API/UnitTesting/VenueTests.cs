using Bogus;
using Common.Interfaces.Data;
using Common.Models;
using FakeItEasy;
using Logic;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    public class VenueTests
    {
        public Mock<IVenueRepository> _VenueInterfaceMock;

        public VenueTests()
        {
            _VenueInterfaceMock = new Mock<IVenueRepository>();
        }

        [Fact]
        public async void Get_Venue_From_Id()
        {
            Faker<VenueModel> faker = new Faker<VenueModel>();
            faker.RuleFor(v => v.id, F => F.UniqueIndex);
            faker.RuleFor(v => v.VenueName, F => F.Company.CompanyName());
            faker.RuleFor(v => v.Description, F => F.Person.Email);

            VenueModel venue = faker.Generate();

            _VenueInterfaceMock.Setup(v => v.GetVenueById(venue.id)).Returns(Task.FromResult(venue));

            VenueLogic venueLogic = new VenueLogic(_VenueInterfaceMock.Object);

            var result = venueLogic.GetVenueById(venue.id);

            Assert.IsType(typeof(Task<VenueModel>), result);
        }



    }
}
