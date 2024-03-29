using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

[assembly: CLSCompliant(false)]
namespace AzureToolkit
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
