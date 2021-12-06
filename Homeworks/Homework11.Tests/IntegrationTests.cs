using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;


namespace Homework11.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class ProgramTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient client;

        public ProgramTests(HostBuilder fixture)
        {
            client = fixture.CreateClient();
        }

        private async Task<string> GetResultAsync(string expression)
        {
            var response =
                await client.GetAsync($"http://localhost:5000/Calculator/Calculate?expression={expression}");
            return await response.Content.ReadAsStringAsync();
        }

        private async Task CheckResultAsync(string expression, string expected)
        {
            var result = await GetResultAsync(expression);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("220+8", "228")]
        [InlineData("2+2*2", "6")]
        [InlineData("1+2+3+4+5", "15")]
        [InlineData("1*2*3*4*5", "120")]
        [InlineData("(10*10)+(18+12)/(25-15)", "103")]
        [InlineData("(10+15)*(23-20)/(10*10)+22/11", "2.75")]
        public async Task Program_CorrectValues_CorrectResultReturned(string expression, string expected)
        {
            await CheckResultAsync(expression, expected);
        }
    }
}