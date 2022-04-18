using BootcampProject.Core.Abstract;
using BootcampProject.Core.Concretes;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.Core.MappingProfiles;
using BootcampProject.Core.Validators;
using BootcampProject.DataAccess.EntityFramework;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.DataAccess.EntityFramework.Repository.Concretes;
using BootcampProject.Domain.Entities;
using BootcampProject.Web.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace BootcampProject.Web
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
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddControllersWithViews().AddFluentValidation(fv => 
                    {
                        fv.DisableDataAnnotationsValidation = true;
                        fv.ImplicitlyValidateChildProperties = true;
                    });

            services.AddTransient<IValidator<LoginDto>, LoginValidator>();
            services.AddTransient<IValidator<CreateUserDto>, CreateUserValidator>();
            services.AddTransient<IValidator<UpdateUserDto>, UpdateUserValidator>();

            services.AddTransient<IValidator<CreateApartmentDto>, CreateApartmentValidator>();
            services.AddTransient<IValidator<UpdateApartmentDto>, UpdateApartmentValidator>();


            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IApartmentService, ApartmentService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            services.AddRazorPages();
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

            app.UseCustomExceptionMiddleware();

            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden ||
                    response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    response.Redirect("/404");
                }    
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
