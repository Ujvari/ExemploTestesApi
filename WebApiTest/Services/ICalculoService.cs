// WebApiTest/WebApiTest/ICalculoService.cs/13/04/2021

namespace WebApiTest.Services
{
	/// <summary>
	/// </summary>
	public interface ICalculoService
	{
		/// <summary>
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		int Divisao(int numeroA, int numeroB);

		/// <summary>
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		int Multiplicacao(int numeroA, int numeroB);

		/// <summary>
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		int Soma(int numeroA, int numeroB);

		/// <summary>
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		int Subtracao(int numeroA, int numeroB);
	}
}
