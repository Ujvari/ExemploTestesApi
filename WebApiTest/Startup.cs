// WebApiTest/WebApiTest/Startup.cs/13/04/2021

#region USINGS

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebApiTest.Services;

#endregion

namespace WebApiTest
{
	/// <summary>
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// <summary>
		///     Este método é obrigatório para utilização de client dinamico
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		/// <summary>
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ICalculoService, CalculoService>();

			services.AddControllers();
		}
	}
}
