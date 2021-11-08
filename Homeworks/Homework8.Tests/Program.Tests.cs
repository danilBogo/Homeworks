using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Homework8.Tests
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
		
		private async Task CheckResult(string v1, string operation, string v2, string expected)
		{
			var response =
				await client.GetAsync($"http://localhost:5000/Calculator/{operation}?arg1={v1}&arg2={v2}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}
		
		[Theory]
		[InlineData("224", "Add", "4", "228")]
		[InlineData("1500", "Minus", "12", "1488")]
		[InlineData("6", "Multiply", "7", "42")]
		[InlineData("15", "Divide", "4", "3.75")]
		public async Task Program_CorrectValues_CorrectResultReturned(string v1,
			string operation,
			string v2,
			string expected)
		{
			await CheckResult(v1, operation, v2, expected);
		}
		
		[Fact]
		public async Task Program_DivideByZero_DivideByZeroExceptionReturned()
		{
			var response =
				await client.GetAsync($"http://localhost:5000/Calculator/Divide?arg1=10&arg2=0");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal("Divide by zero exception", result);
		}
	}
}