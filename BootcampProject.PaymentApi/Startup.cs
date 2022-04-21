using BootcampProject.DataAccess.MongoDB.Repository.Abstract;
using BootcampProject.DataAccess.MongoDB.Repository.Concrete;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace BootcampProject.PaymentApi
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
            // get connection options
            services.Configure<UserStoreDatabaseSettings>(Configuration.GetSection("ConnectionStrings"));
            // add connection as singleton
            services.AddSingleton<IUserStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<UserStoreDatabaseSettings>>().Value);
            // add mongodb to connect database
            services.AddSingleton<IMongoClient>(s => new MongoClient(Configuration.GetValue<string>("ConnectionStrings:conn")));

            services.AddTransient<ICreditCardPaymentRepository, CreditCardPaymentRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BootcampProject.PaymentApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BootcampProject.PaymentApi v1"));
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
