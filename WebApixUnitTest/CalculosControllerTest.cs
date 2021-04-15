// WebApiTest/WebApixUnitTest/CalculosControllerTest.cs/13/04/2021

#region USINGS

using System;
using System.Threading.Tasks;

using Xunit;

#endregion

namespace WebApixUnitTest
{
	public class CalculosControllerTest
	{
		/// <summary>
		///     Valida se a divis�o est� retornando os resultados corretos
		/// </summary>
		/// <param name="numeroA">N�mero a ser dividido</param>
		/// <param name="numeroB">N�mero divisor</param>
		/// <param name="resultadoEsperado">Resultado da divis�o esperado</param>
		/// <returns></returns>
		[Theory(DisplayName = "Valida divis�o entre 2 n�meros")]
		[InlineData(10, -2, -5)]
		[InlineData(-1, 10, 0)]
		[InlineData(10, 2, 5)]
		public async Task ValidaDivisao(int numeroA, int numeroB, int resultadoEsperado)
		{
			//Arrange
			using var client = new TestClientProvider("Development").Client;

			//Act
			var response = await client.GetStringAsync($"/calculos/divide/{numeroA}/{numeroB}");

			//Assert
			Assert.NotNull(response);
			Assert.IsType<string>(response);
			Assert.Equal(resultadoEsperado, int.Parse(response));
		}
	}
}
