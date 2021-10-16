using Infrastruture.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System;
using Web.Helpers;
using Web.Services;
using Web.ViewModels;
using Web.Areas.Auth.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Web.Interfaces;

namespace Web
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddDbContext<WebContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("WebContext")));
			services.AddRazorPages()
				.AddRazorRuntimeCompilation()
				.AddRazorPagesOptions(options =>
				{
				options.Conventions.AddAreaPageRoute("Auth","/Login", "");
			});

			services.AddHttpContextAccessor();
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

			services.AddTransient<UserApiAuthHandler>();

			services.AddHttpClient<IUserApiAuthService, UserApiAuthService>()
					.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44327/"));

			services.AddHttpClient<IUserService, UserService>()
					.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44327/"))
					.AddHttpMessageHandler<UserApiAuthHandler>();

			services.AddHttpClient<IMentionService, MentionService>()
					.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44327/"))
					.AddHttpMessageHandler<UserApiAuthHandler>();	

			// Add Authentication services
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.HttpOnly = true;
					options.Cookie.IsEssential = true;
					options.Cookie.Name = "InDeBuurt";
					options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseStatusCodePages();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapRazorPages();
			});
		}
	}
}
