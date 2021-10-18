using Infrastruture.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PublicAPI.Helpers;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using PublicAPI.Interfaces;
using PublicAPI.Services;
using ApplicationCore.Entities;
using Microsoft.Extensions.Azure;

namespace PublicAPI
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
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddDbContext<WebContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("WebContext")));
			services.AddControllersWithViews();
			services.AddMvc();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
			});


			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IMentionService, MentionService>();
			services.AddCors();
			services.AddControllers();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//Configure AzureBlobService
			services.AddAzureClients(builder =>
			{
				builder.AddBlobServiceClient(Configuration.GetSection("Storage:ConnectionString").Value);
			});

			services.AddTransient<IStorageService, StorageService>();

			// configure strongly typed settings objects
			IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			// configure jwt authentication
			AppSettings appSettings = appSettingsSection.Get<AppSettings>();
			byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddCookie(x => 
			{ 
				x.Cookie.Name = "IDB.API";
			})
			.AddJwtBearer(x =>
			{
				x.Events = new JwtBearerEvents
				{
					OnTokenValidated = context =>
					{
						IUserService userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
						int userId = int.Parse(context.Principal.Identity.Name);
						User user = userService.GetById(userId);
						if (user == null)
						{
							// return unauthorized if user no longer exists
							context.Fail("Unauthorized");
						}
						return Task.CompletedTask;
					}
				};
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.InjectStylesheet("/swagger/custom.css");
				c.RoutePrefix = String.Empty;
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
