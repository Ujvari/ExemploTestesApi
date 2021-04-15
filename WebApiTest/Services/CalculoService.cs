// WebApiTest/WebApiTest/CalculoService.cs/13/04/2021

#region USINGS

using System;

#endregion

namespace WebApiTest.Services
{
	/// <summary>
	/// 
	/// </summary>
	public class CalculoService : ICalculoService
	{
		/// <inheritdoc />
		public int Divisao(int numeroA, int numeroB)
		{
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
