using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Play.Common.MassTransit;
using Play.Users.Service.Entities;
using Play.Common.Service.Settings;
using Play.Users.Service.Data;
using Microsoft.EntityFrameworkCore;
using Play.Users.Service.Repository;
using Play.Common.SqlServer;

namespace Play.Users.Service
{
    public class Startup
    {
        private ServiceSettings serviceSetting;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMassTransitRabbitMq()
                .AddSqlServerDbContext<UsersDbContext>(Configuration)
                .AddSqlServerRepository<User>();

            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDb")));
            // services.AddScoped(typeof(IRepository<User>), typeof(SqlRespository<User>));
            // services.AddScoped<DbContext, UsersDbContext>(); //services.AddScoped<DbContext, UsersDbContext>();   // services.AddDbContext<UsersDbContext>(options =>
            // {
            //     options.UseSqlServer(
            //     Configuration.GetConnectionString("UsersDb"));
            // });
            // services.AddScoped<DbContext, UsersDbContext>();
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Play.Users.Service", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Play.Users.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
