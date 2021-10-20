using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IHost host = CreateHostBuilder(args).Build();
			//CreateDbIfNotExist(host);
			host.Run();
		}

		//private static void CreateDbIfNotExist(IHost host)
		//{
		//	using IServiceScope scope = host.Services.CreateScope();
		//	IServiceProvider services = scope.ServiceProvider;
		//	try
		//	{
		//		WebContext context = services.GetRequiredService<WebContext>();
		//		context.Database.EnsureCreated();
		//		// DbInitializer.Initialize(context);
		//	}
		//	catch (Exception ex)
		//	{
		//		ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
		//		logger.LogError(ex, "An error occurred creating the DB.");
		//	}
		//}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
