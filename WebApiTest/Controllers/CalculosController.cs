// WebApiTest/WebApiTest/CalculosController.cs/13/04/2021

#region USINGS

using Microsoft.AspNetCore.Mvc;

using WebApiTest.Services;

#endregion

namespace WebApiTest.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("calculos")]
	[ApiController]
	public class CalculosController : ControllerBase
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="service"></param>
		public CalculosController(ICalculoService service)
		{
			_calculoService = service;
		}

		private readonly ICalculoService _calculoService;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		[Route("divide/{numeroA:int}/{numeroB:int}")]
		[HttpGet]
		public ActionResult<int> Divisao(int numeroA, int numeroB)
		{
			var divisao = _calculoService.Divisao(numeroA, numeroB);
			return Ok(divisao);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		[Route("multiplica/{numeroA:int}/{numeroB:int}")]
		[HttpGet]
		public ActionResult<int> Multiplicacao(int numeroA, int numeroB)
		{
			var mult = _calculoService.Multiplicacao(numeroA, numeroB);
			return Ok(mult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		[Route("mais/{numeroA:int}/{numeroB:int}")]
		[HttpGet]
		public ActionResult<int> Soma(int numeroA, int numeroB)
		{
			var soma = _calculoService.Soma(numeroA, numeroB);
			return Ok(soma);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="numeroA"></param>
		/// <param name="numeroB"></param>
		/// <returns></returns>
		[Route("menos/{numeroA:int}/{numeroB:int}")]
		[HttpGet]
		public ActionResult<int> Subtracao(int numeroA, int numeroB)
		{
			var subtracao = _calculoService.Subtracao(numeroA, numeroB);
			return Ok(subtracao);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Route("saude")]
		[HttpGet]
		public ActionResult HealthCheck()
		{
			return Ok();
		}
	}
}
