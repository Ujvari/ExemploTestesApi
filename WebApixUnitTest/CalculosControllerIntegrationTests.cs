// WebApiTest/WebApixUnitTest/CalculosControllerIntegrationTests.cs/14/04/2021

#region USINGS

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xunit;

#endregion

namespace WebApixUnitTest
{
	public class CalculosControllerIntegrationTests
	{
		/// <summary>
		///     Valida se os métodos HTTP estão corretos
		/// </summary>
		/// <param name="metodo">Método</param>
		/// <param name="numeroA">Parametro para chamada</param>
		/// <param name="numeroB">Parametro para chamada</param>
		/// <returns></returns>
		[Theory(DisplayName = "Valida se os métodos HTTP estão corretos")]
		[InlineData("POST", 10, 5)]
		[InlineData("GET", 10, 5)]
		public async Task ValidaSeOMetodoHttpEstaCorreto(string metodo, int numeroA, int numeroB)
		{
			//Arranjo
			using var client = new TestClientProvider("Development").Client;
			var request = new HttpRequestMessage(new HttpMethod(metodo), $"calculos/mais/{numeroA}/{numeroB}");

			//Ação
			var response = await client.SendAsync(request);

			//Afirmação
			response.EnsureSuccessStatusCode();
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		[Theory(DisplayName = "Valida se todas as chamadas da API estão funcionando")]
		[InlineData("/calculos/mais/10/20")]
		[InlineData("/calculos/menos/20/30")]
		[InlineData("/calculos/divide/20/10")]
		[InlineData("/calculos/multiplica/20/150")]
		public async Task ValidaSeTodasAsChamadasDaApiRetornamOContentTypeErrado(string url)
		{
			//Arrange
			using var client = new TestClientProvider("Development").Client;

			//Act
			var response = await client.GetAsync(url);

			//Assert
			response.EnsureSuccessStatusCode();
			Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
		}

		/// <summary>
		///     Testa multiplas chamadas para a API para verificar se todas retornam o ContentType correto
		/// </summary>
		/// <param name="url">Ulr a ser chamada</param>
		/// <returns></returns>
		[Theory(DisplayName = "Valida se todas as chamadas da API estão funcionando")]
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
			Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
		}

		public static IEnumerable<object[]> Urls =>
			new List<object[]>
			{
				new object[]
				{
					"/calculos/mais/10/20"
				},
				new object[]
				{
					"/calculos/menos/20/30"
				},
				new object[]
				{
					"/calculos/divide/20/10"
				},
				new object[]
				{
					"/calculos/multiplica/20/150"
				}
			};

		/// <summary>
		///     Testas todas as chamadas da API usando MemberData
		/// </summary>
		/// <param name="url">Url que será usada na chamada</param>
		/// <returns></returns>
		[Theory(DisplayName = "Valida o ContentType das Chamadas com MemberData")]
		[MemberData(nameof(Urls))]
		public async Task ValidaSeTodasAsChamadasDaApiRetornamOContentTypeCertoUsandoMemberData(string url)
		{
			//Preparação
			using var client = new TestClientProvider("Development").Client;

			//Ação
			var response = await client.GetAsync(url);

			//Afirmação
			response.EnsureSuccessStatusCode();
			Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
		}

		/// <summary>
		///     Testas todas as chamadas da API usando MemberData
		/// </summary>
		/// <param name="url">Url que será usada na chamada</param>
		/// <returns></returns>
		[Theory(DisplayName = "Valida o ContentType das Chamadas com MemberData de classe externa")]
		[MemberData(nameof(TestsParameters.Urls), MemberType = typeof(TestsParameters))]
		public async Task ValidaSeTodasAsChamadasDaApiRetornamOContentTypeCertoUsandoMemberDataExterno(string url)
		{
			//Preparação
			using var client = new TestClientProvider("Development").Client;

			//Ação
			var response = await client.GetAsync(url);

			//Afirmação
			response.EnsureSuccessStatusCode();
			Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
		}

		/// <summary>
		///     Testa saúde do serviço
		/// </summary>
		/// <returns></returns>
		[Fact(DisplayName = "Valida endereço do Serviço")]
		public async Task ValidaSaudeDaApi()
		{
			using var client = new TestClientProvider("Development").Client;

			var response = await client.GetAsync($"/calculos/saude");

			Assert.True(response.IsSuccessStatusCode);
		}
	}
}
