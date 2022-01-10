using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using FluentAssertions;
using Xunit;

namespace Integration_Tests
{
    public class PostIntegrationTesting : Base
    {
        [Fact]
        public async Task PostToDatabase()
        {
            //Arrange
            EventModel EventObject = new();

            EventObject.Description = "Spaghetti";
            EventObject.EventName = "SpaghettiFeest";

            //Act
            HttpResponseMessage response = await TestClient.PostAsJsonAsync("Event", EventObject);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}
