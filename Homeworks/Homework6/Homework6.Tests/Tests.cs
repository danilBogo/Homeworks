using System.Net.Http;
using System.Threading.Tasks;
using Giraffe;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Homework6.Tests
{
	public class HostBuilder : WebApplicationFactory<App.Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<App.Startup>()
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
				await client.GetAsync($"http://localhost:5000/calculate?v1={v1}&Op={operation}&v2={v2}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}
		
		[Theory]
		[InlineData("224", "plus", "4", "228.0")]
		[InlineData("1500", "minus", "12", "1488.0")]
		[InlineData("6", "multiply", "7", "42.0")]
		[InlineData("15", "divide", "4", "3.75")]
		public async Task Program_CorrectValues_CorrectResultReturned(string v1,
			string operation,
			string v2,
			string expected)
		{
			await CheckResult(v1, operation, v2, expected);
		}

		[Theory]
		[InlineData("x", "plus", "4", "InvalidArgument")]
		[InlineData("10", "minus", "z", "InvalidArgument")]
		[InlineData("11", "x", "30", "InvalidOperation")]
		[InlineData("11", "divide", "0", "DivideByZero")]
		public async Task Program_InvalidSyntax_ErrorReturned(string v1,
			string operation,
			string v2,
			string expected)
		{
			await CheckResult(v1, operation, v2, expected);
		}

		[Fact]
		public async Task Program_InvalidPagePath_PageNotFoundReturned()
		{
			var response =
				await client.GetAsync($"http://localhost:5000/zxc");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal("Not Found", result);
		}
	}
}