using FluentAssertions;
using MediatrSample.Api.Models;
using MediatrSample.Application.Commands.AddClientCommand;
using MediatrSample.Domain.Entities;
using MediatrSample.Infrastructure.SqlContext;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MediatrSample.Test.IntegrationTests
{
    public class ClientControllerTests : InMemoryTestingContext, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ClientControllerTests(WebApplicationFactory<Startup> factory) 
        : base(new DbContextOptionsBuilder<MediatrSampleDbContext>()
                .UseInMemoryDatabase("ClientDb")
                .Options)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_Should_Add_Client()
        {
            var newClient = new ClientDto()
            {
                FirstName = "TTTT",
                LastName = "HHHH"
            };

            var client = _factory.WithWebHostBuilder(builder =>
            {
                //Do custom stuff here. Mocks and what nots                
            })
            .CreateClient();

            var response = await client.PostAsync("/Client",
                new StringContent(JsonConvert.SerializeObject(newClient), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Get_Should_Return_Client()
        {
            var newClient = new ClientDto()
            {
                FirstName = "TTTT",
                LastName = "HHHH"
            };

            var client = _factory.WithWebHostBuilder(builder =>
            {
                //Do custom stuff here. Mocks and what nots                
            })
            .CreateClient();

            var response = await client.PostAsync("/Client",
                new StringContent(JsonConvert.SerializeObject(newClient), Encoding.UTF8, "application/json"));

            var newClientId = await response.Content.ReadAsStringAsync();

            var getResponse = await client.GetAsync($"/Client/{newClientId}");
            var addedClient = JsonConvert.DeserializeObject<ClientDto>(await getResponse.Content.ReadAsStringAsync());

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            addedClient.FirstName.Should().Be("TTTT");
            addedClient.LastName.Should().Be("HHHH");
        }

        [Fact]
        public async Task Get_All_Should_Return_All_Client()
        {
            Seed();
            var client = _factory.WithWebHostBuilder(builder =>
            {
                //Do custom stuff here. Mocks and what nots                
            })
            .CreateClient();

            var getResponse = await client.GetAsync($"/Client");
            var clients = JsonConvert.DeserializeObject<List<ClientDto>>(await getResponse.Content.ReadAsStringAsync());

            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            clients.Count().Should().Be(4);
        }

        protected override void Seed()
        {
            using (var context = new MediatrSampleDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Clients.AddRange(
                    new Client("AA", "BB"),
                    new Client("CC", "DD"),
                    new Client("EE", "FF"),
                    new Client("GG", "HH"));

                context.SaveChanges();
            }
        }
    }
}
