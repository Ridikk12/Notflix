using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notflix.Core.Helpers;
using Notflix.Services;
using Notflix.Services.User;
using Notflix.Services.User.Interfaces;
using NotFlix2.Maps;
using Notlifx.Data;
using Notlifx.Data.Repositories;
using Notlifx.Data.Repositories.Interfaces;

namespace NotFlix2
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
			services.AddMvc();
			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie();
		
			services.AddDbContext<NotflixDbContext>(options =>
						options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup),typeof(UserAccountService));
            RegisterDependency(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStaticFiles();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

				routes.MapSpaFallbackRoute(
					name: "spa-fallback",
					defaults: new { controller = "Home", action = "Index" });
			});


		}


		private void RegisterDependency(IServiceCollection service)
		{
			service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IUserAccountService, UserAccountService>();
			service.AddScoped<IUserHelper, UserHelper>();
			service.AddScoped<IVideoService, VideoService>();
			service.AddScoped<IGenderRepository, GenderRepository>();
			service.AddScoped<IVideoRepository, VideoRepository>();
           


		}

	}
}
