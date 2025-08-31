using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Day29_E_Commerce_assignment.Tests
{
    public class RoutingTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public RoutingTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ProductDetailsRoute_ReturnsSuccess()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/Products/electronics/1");
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }

        [Fact]
        public async Task ProductFilterRoute_ValidRange_ReturnsSuccess()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/Products/Filter/books/100-500");
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }

        [Fact]
        public async Task ProductFilterRoute_InvalidRange_ReturnsNotFound()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/Products/Filter/books/abc");
            Assert.Equal(HttpStatusCode.NotFound, res.StatusCode);
        }

        [Fact]
        public async Task UserOrdersRoute_ReturnsSuccess()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/Users/john/Orders");
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }

        [Fact]
        public async Task Dashboard_AsAdmin_RendersAdminView()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            // login as admin
            var loginRes = await client.GetAsync("/Account/Login?role=Admin");
            Assert.Equal(HttpStatusCode.Redirect, loginRes.StatusCode);

            var res = await client.GetAsync("/Dashboard");
            var body = await res.Content.ReadAsStringAsync();
            Assert.Contains("Admin Dashboard", body);
        }
    }
}
