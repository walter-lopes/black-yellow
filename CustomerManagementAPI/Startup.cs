
using BlackYellow.Infrastructure.Messaging;
using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace CustomerManagementAPI
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

            // Registro os objetos que vou usar na aplicação
            services.AddSingleton(this.Configuration);
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher("localhost", "guest", "guest", "blackyellow"));

            services.AddScoped<IDbContext>(sp =>
            {
                return new MongoContext()
                {
                    ConnectionString = this.Configuration.GetSection("Mongo:ConnectionString").Get<string>(),
                    DataBase = this.Configuration.GetSection("Mongo:DataBase").Get<string>()
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseMvc();
        }
    }
}
