using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplicationBasic.Models;

namespace AzureToolkit
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist/browser";
			});

			services.AddHsts(options =>
			{
				options.Preload = true;
				options.IncludeSubDomains = true;
				options.MaxAge = TimeSpan.FromDays(60);
				//options.ExcludedHosts.Add("example.com");
				//options.ExcludedHosts.Add("www.example.com");

				/*
				UseHsts excludes the following loopback hosts:
				� localhost: The IPv4 loopback address.
				� 127.0.0.1 : The IPv4 loopback address.
				� [::1] : The IPv6 loopback address.
				*/
				options.ExcludedHosts.Clear();
			});

			/*
			 * Once again, in a real-world project you should NOT hard code a connection string in code, you should read it in from a configuration file. But we are keeping it simple for the purpose of this course.
			 */
			//var connection = @"Server=tcp:azuretoolkit-oleier.database.windows.net,1433;Initial Catalog=azuretoolkit;Persist Security Info=False;User ID=OLeier;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			var connection = @"Server=tcp:azuretoolkit-oleier.database.windows.net,1433;Initial Catalog=azuretoolkit;Persist Security Info=False;User ID=OLeier;Password=i5ffPv48z3FKRj9XEGpZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			services.AddDbContext<AzureToolkitContext>(options => options.UseSqlServer(connection));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				context.Response.OnStarting(() =>
				{
					//context.Response.Headers.Add("MyHeader", "GotItWorking!!!");
					Startup.AddSecurityHeaders(context.Response.Headers);
					Trace.WriteLine("context.Response.Headers: " + context.Response.Headers.Count);
					return Task.FromResult(0);
				});
				await next().ConfigureAwait(false);
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				//app.UseHsts();
			}

			app.UseHsts();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseRouting();

			//app.UseMvc(routes =>
			//{
			//	routes.MapRoute(
			//		name: "default",
			//		template: "{controller}/{action=Index}/{id?}");
			//});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});

		}

		/// <summary>
		/// AddSercurityHeaders
		/// </summary>
		/// <remarks>
		/// https://spacehost.de/10-apache-header-eintraege-webseite-sicher-machen/
		/// https://webbkoll.dataskydd.net/
		/// https://securityheaders.com/
		/// https://observatory.mozilla.org/
		/// </remarks>
		/// <param name="headers"></param>
		static private void AddSecurityHeaders(IHeaderDictionary headers)
		{
			/*
			#1) HTTP Strict Transport Security (HSTS)
			# HSTS verwenden
			# Pflichtangabe: �max-age�
			# Optional: �includeSubDomains�
			# Header set Strict-Transport-Security "max-age=63072000; includeSubDomains; preload"
			*/
			if (!headers.ContainsKey("Strict-Transport-Security"))
			{
				headers.Add("Strict-Transport-Security", "max-age=63072000; includeSubDomains; preload");
			}

			/*
			#2) X-Content-Type-Options
			# Verhindert mime based attacks, nur IE und Chrome
			Header set X-Content-Type-Options "nosniff"
			*/
			if (!headers.ContainsKey("X-Content-Type-Options"))
			{
				headers.Add("X-Content-Type-Options", "nosniff");
			}

			/*
			#3) X-XSS-Protection
			# Aktiviert XSS Praeventions-/Filter-Tools
			# Optional: mode=block
			Header set X - XSS - Protection "1; mode=block"
			*/
			if (!headers.ContainsKey("X-XSS-Protection"))
			{
				headers.Add("X-XSS-Protection", "1; mode=block");
			}

			/*
			#4) X-Frame-Options
			# Begrenzung der frame/iframe Darstellung
			Header append X - Frame - Options "SAMEORIGIN"
			*/
			if (!headers.ContainsKey("X-Frame-Options"))
			{
				headers.Add("X-Frame-Options", "SAMEORIGIN");
			}

			/*
			#5) HTTP Public Key Pinning (HPKP)
			*/

			/*
			#6) Set-Cookie
			# Cookies nur ueber SSL and kein Javascript Zugriff
			# Optional: Expires, Max-Age, Path, Domain
			Header always edit Set-Cookie(.*) "$1; HttpOnly; Secure"
			*/

			/*
			#7) X-Powered-By
			# Kein PHP und System-Version ausgeben
			# - Header unset X-Powered-By

			# - Header set Report-To " { \"group\": \"endpoint\", \"max-age\": 10886400, \"endpoints\": [ { \"url\": \"https://www.ib-leier.net/report-uri/report.php?t=rt\" } ] }"
			*/

			/*
			#8) Content-Security-Policy (CSP)
			# Download / Lade Inhalte nur von Seiten die explizit erlaubt sind
			# Beispiel das alles von der eigenen Domain erlaubt allerdings keinerlei Externas:
			# Header set Content-Security-Policy "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self';" - kein internal CSS
			*/

			/*
			#9) Referrer Policy
			# Referrer Policy
			# Header set Referrer-Policy "origin-when-cross-origin"
			Header set Referrer - Policy "no-referrer"
			*/
			if (!headers.ContainsKey("Referrer-Policy"))
			{
				headers.Add("Referrer-Policy", "no-referrer");
			}

			/*
			#10) Expect-CT
			# Expect-CT fuer kommende Implementation Okt 2017
			# Header set Expect-CT "max-age=0; report-uri=https://domainname.endung/reportOnly"
			Header set Expect - CT "max-age=0, report-uri=\"http://report-uri.ib-leier.net/report-uri-expect-ct.php\""

			# https://scotthelme.co.uk/a-new-security-header-expect-ct/
			*/
		}
	}
}
