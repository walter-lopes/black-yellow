 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductManagementAPI.DataAccess;

namespace ProductManagementAPI
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

            services.AddSingleton(this.Configuration);

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher("localhost", "guest", "guest", "blackyellow"));

            services.AddScoped<IDbContext>(sp  =>
            {
                return new MongoContext()
                {
                    ConnectionString = this.Configuration.GetSection("Mongo:ConnectionString").Get<string>(),
                    DataBase = this.Configuration.GetSection("Mongo:DataBase").Get<string>()
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
