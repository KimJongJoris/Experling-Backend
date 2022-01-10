using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Integration_Tests
{
    public class GetAllIntegrationTest : Base
    {
        [Theory]
        [InlineData("Event")]
        [InlineData("Band")]
        [InlineData("Customer")]
        [InlineData("Ticket")]
        [InlineData("Venue")]
        public async Task GetAll_IntegrationTest(string endpoint)
        {
            // Arrange

            // don

            // Act
            var response = await TestClient.GetAsync(endpoint);
         

            // Assert
           Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
