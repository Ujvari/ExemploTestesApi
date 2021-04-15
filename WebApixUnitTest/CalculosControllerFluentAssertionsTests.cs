// WebApiTest/WebApixUnitTest/CalculosControllerFluentAssertionsTests.cs/14/04/2021

#region USINGS

using System.Threading.Tasks;

using FluentAssertions;
using FluentAssertions.Extensions;

using Xunit;

#endregion

namespace WebApixUnitTest
{
	public class CalculosControllerFluentAssertionsTests
	{
		[Theory(DisplayName = "Valida divisão entre 2 números")]
		[InlineData(10, -2, -5)]
		[InlineData(-1, 10, 0)]
		[InlineData(10, 2,  5)]
		public async Task ValidaDivisao(int numeroA, int numeroB, int resultadoEsperado)
		{
			using var client = new TestClientProvider("Development").Client;

			var response = await client.GetStringAsync($"/calculos/divide/{numeroA}/{numeroB}");

			response.Should().NotBeNull();
			response.Should().NotBeEmpty();
			response.Should().Be(resultadoEsperado.ToString());
			int.Parse(response).Should().BePositive();
		}

		[Fact(DisplayName = "Valida saúde da API via FluentAssertions")]
		public async Task ValidaSaudeDaApi()
		{
			using var client = new TestClientProvider("Development").Client;

			client.ExecutionTimeOf(obj => obj.GetAsync($"/calculos/saude")).Should().BeLessOrEqualTo(100.Milliseconds());
		}

		[Theory(DisplayName = "Valida chamadas da API com FluentAssertions")]
		[InlineData("/calculos/mais/10/20")]
		[InlineData("/calculos/menos/20/30")]
		[InlineData("/calculos/divide/20/10")]
		[InlineData("/calculos/multiplica/20/150")]
		public async Task ValidaSeTodasAsChamadasDaApiRetornamOContentTypeCerto(string url)
		{
			//Preparação
			using var client = new TestClientProvider("Development").Client;

			//Ação
			var response = await client.GetAsync(url);

			//Afirmação
			response.EnsureSuccessStatusCode();
			response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
		}
	}
}
