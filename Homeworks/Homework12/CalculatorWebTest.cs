using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Giraffe;
using Homework8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Homework12
{
    public class HostBuilderFSharp : WebApplicationFactory<App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<App.Startup>()
                    .UseTestServer());
    }

    public class HostBuilderCSharp : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    [MinColumn]
    [MaxColumn]
    [StdDevColumn]
    [StdErrorColumn]
    [MedianColumn]
    public class CalculatorWebTest
    {
        private HttpClient clientCSharp;
        private HttpClient clientFSharp;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            clientCSharp = new HostBuilderCSharp().CreateClient();
            clientFSharp = new HostBuilderFSharp().CreateClient();
        }


        [Benchmark(Description = "C# 2220Plus8888")]
        public async Task PlusCSharp()
        {
            await clientCSharp.GetAsync("http://localhost:5000/Calculator/Add?arg1=2220&arg2=8888");
        }
        
        [Benchmark(Description = "C# 12313Minus3221")]
        public async Task MinusCSharp()
        {
            await clientCSharp.GetAsync("http://localhost:5000/Calculator/Minus?arg1=12313&arg2=3221");
        }
        
        [Benchmark(Description = "C# 423234Multiply123")]
        public async Task MultiplyCSharp()
        {
            await clientCSharp.GetAsync("http://localhost:5000/Calculator/Multiply?arg1=423234&arg2=123");
        }
        
        [Benchmark(Description = "C# 42234Divide21")]
        public async Task DivideCSharp()
        {
            await clientCSharp.GetAsync($"http://localhost:5000/Calculator/Divide?arg1=42234&arg2=21");
        }
        
        [Benchmark(Description = "F# 2220Plus8888")]
        public async Task PlusFSharp()
        { 
            await clientFSharp.GetAsync(  "http://localhost:5000/calculate?v1=2220&Op=plus&v2=8888");
        }
        
        [Benchmark(Description = "F# 12313Minus3221")]
        public async Task MinusFSharp()
        {
            await clientFSharp.GetAsync("http://localhost:5000/calculate?v1=12313&Op=minus&v2=3221");
        }
        
        [Benchmark(Description = "F# 423234Multiply123")]
        public async Task MultiplyFSharp()
        {
            await clientFSharp.GetAsync("http://localhost:5000/calculate?v1=423234&Op=multiply&v2=123");
        }
        
        [Benchmark(Description = "F# 42234Divide21")]
        public async Task DivideFSharp()
        {
            await clientFSharp.GetAsync("http://localhost:5000/calculate?v1=42234&Op=divide&v2=21");
        }
    }
}