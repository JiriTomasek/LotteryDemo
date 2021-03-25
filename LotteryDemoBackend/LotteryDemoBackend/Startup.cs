using System;
using System.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Core.Entities.DAO;
using LotteryDemo.Database.DAO;
using LotteryDemo.Database.DbContext;
using LotteryDemo.Domain.BlProvider.Impl;
using LotteryDemo.Domain.BlProvider.Interface;
using LotteryDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LotteryDemoBackend
{
    public class Startup
    {
        public static readonly ILoggerFactory ToolLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<LotteryDemoDbContext>(options => options.UseLoggerFactory(ToolLoggerFactory)
                    .EnableSensitiveDataLogging(true)
                    .UseSqlServer(Configuration.GetConnectionString(LotteryDemoDbContextFactory.GetConnStringName("Lottery-demo"))),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient);


            services.AddTransient<IBaseDaoFactory, LotteryDemoDaoFactory>();
            services.AddTransient<ILotteryDemoBlProvider, LotteryDemoBlProvider>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LotteryDemo.API", Version = "v1" });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LotteryDemo.API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            DatabaseVerify(hostApplicationLifetime);
        }

        private void DatabaseVerify(IHostApplicationLifetime hostApplicationLifetime)
        {
            var factory = new LotteryDemoDaoFactory(new LotteryDemoDbContext());
            var dbDrawDao = factory.GetDifferentContextDao<Draw>();
            dbDrawDao.Migrate();
            if (!dbDrawDao.TestConnection())
            {
                ToolLoggerFactory.CreateLogger<Startup>().LogCritical("Invalid connection string or database not exist.");
                hostApplicationLifetime.StopApplication();
            }
        }
    }
}
