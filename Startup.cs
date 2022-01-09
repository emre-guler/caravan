using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Caravan.Data;
using Caravan.Interfaces;
using Caravan.Mapping;
using Caravan.Service;
using EasyCaching.Core.Configurations;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Caravan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => {
                    x.LoginPath = "/customer/login";
                });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllersWithViews();
            services.AddDbContext<CaravanContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped(typeof(IValidationService<>), typeof(ValidationService<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICurrentCustomerService, CurrentCustomerService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IRecurringJobService, RecurringJobService>();
            services.AddEasyCaching(opitons => 
            {
                opitons.UseRedis(redisConfig => 
                {
                    redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint("localhost", 6379));
                    redisConfig.DBConfig.AllowAdmin = true;
                    redisConfig.EnableLogging = true;
                },
                "redis");
            });
            services.AddHangfire(config => config.UsePostgreSqlStorage(Configuration.GetConnectionString("DefaultConnectionString")));
            RecurringJob.AddOrUpdate<RecurringJobService>(x => x.GetSuppliersAddresses() , "0 03 00 ? * *");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
