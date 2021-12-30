using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using OnlineBookstore.Entities;
using OnlineBookstore.IntegrationTests.DataTest;
using OnlineBookstore.IntegrationTests.Helpers;
using OnlineBookstore.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace OnlineBookstore.IntegrationTests
{
    public class CustomerControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _client;

        public CustomerControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions=services
                    .SingleOrDefault(s=>s.ServiceType == typeof(DbContextOptions<OnlineBookstoreDbContext>));
                    services.Remove(dbContextOptions);
                    services.AddDbContext<OnlineBookstoreDbContext>(options => options.UseInMemoryDatabase("OnlineBookstoreDb"));               
                });
            }).CreateClient();
        }

        [Theory]
        [ClassData(typeof(RegisterCustomerValidModelTestData))]
        public async void RegisterCustomer_ForValidModel_ReturnsAccepted(RegisterCustomerDTO registerCustomerDTO)
        {
            //arrange
            var registerCustomer = registerCustomerDTO;           
            var httpContent = registerCustomer.ToJsonHttpContent();
            //act
            var response = await _client.PostAsync("/api/customers/register", httpContent);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Accepted);

        }
        [Theory]
        [ClassData(typeof(RegisterCustomerInvalidModelTestData))]
        public async void RegisterCustomer_ForInvalidModel_ReturnsReturnsBadRequest(RegisterCustomerDTO registerCustomerDTO)
        {
            //arrange
            var registerCustomer = registerCustomerDTO;
            var httpContent = registerCustomer.ToJsonHttpContent();
            //act
            var response = await _client.PostAsync("/api/customers/register", httpContent);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }
    }
}