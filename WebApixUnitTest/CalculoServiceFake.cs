// WebApiTest/WebApixUnitTest/CalculoServiceFake.cs/13/04/2021

#region USINGS

using WebApiTest.Services;

#endregion

namespace WebApixUnitTest
{
	public class CalculoServiceFake : ICalculoService
	{
		/// <inheritdoc />
		public int Divisao(int numeroA, int numeroB)
		{
			//if(numeroA < numeroB)
			//	throw new OperationCanceledException("O número A deve ser maior que o numero B");

			return numeroA / numeroB;
		}

		/// <inheritdoc />
		public int Multiplicacao(int numeroA, int numeroB)
		{
			return numeroA * numeroB;
		}

		/// <inheritdoc />
		public int Soma(int numeroA, int numeroB)
		{
			return numeroA + numeroB;
		}

		/// <inheritdoc />
		public int Subtracao(int numeroA, int numeroB)
		{
			return numeroA - numeroB;
		}
	}
}
