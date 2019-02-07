using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Account
{
	public class Startup : IStartup
	{
		private readonly AuthWebConfiguration configuration;

		public Startup(IOptions<AuthWebConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			return services
				.AddDataServices(configuration.AccountContext)
				.AddWebServices(configuration)
				.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.EnsureDatabaseMigrated();
			
			app.UseAuthentication();
			
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Account API v1"));
			
			app.UseMvc();
		}
	}
}