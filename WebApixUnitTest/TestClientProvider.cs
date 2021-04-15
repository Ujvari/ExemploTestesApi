// WebApiTest/WebApixUnitTest/TestClientProvider.cs/13/04/2021

#region USINGS

using System.Net.Http;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using WebApiTest;

#endregion

namespace WebApixUnitTest
{
	public class TestClientProvider
	{
		public TestClientProvider(string environment)
		{
			_server = new TestServer(new WebHostBuilder().UseEnvironment(environment).UseStartup<Startup>());

			Client = _server.CreateClient();
		}

		private readonly TestServer _server;

		public HttpClient Client { get; set; }

		public void Dispose()
		{
			_server?.Dispose();
			Client?.Dispose();
		}
	}
}
