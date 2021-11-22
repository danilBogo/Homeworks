using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Homework9.Tests
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
		
		private async Task CheckResult(string expression, string expected)
		{
			var response =
				await client.GetAsync($"http://localhost:5000/Calculator/Calculate?expression={expression}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}
		
		[Theory]
		[InlineData("220+8" ,"228")]
		[InlineData("2+2*2","6")]
		[InlineData("10*(5+5)","100")]
		[InlineData("100/20/5*88","88")]
		[InlineData("((23-3)+(22+8))/(12+8)","2.5")]
		[InlineData("(10+15)*(23-20)/(10*10)+22/11","2.75")]
		public async Task Program_CorrectValues_CorrectResultReturned(string expression,string expected)
		{
			await CheckResult(expression, expected);
		}
	}
}