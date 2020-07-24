using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManagement.Application;
using HRManagement.Domain;
using HRManagement.Persist;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
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
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DBConnection");

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<EmployeeContext>(o => o.UseSqlServer(connectionString));


        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class DataContextSeed
    {
        public static async Task SeedAsync(EmployeeContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            var retryForAvailability = retry.Value;

            try
            {
                await context.Database.MigrateAsync();
                if (!await context.Employees.AnyAsync())
                {
                    await context.Employees.AddRangeAsync(GetSeedEmployee());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<DataContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }

        public static List<Employee> GetSeedEmployee()
        {
            var id1 = Guid.NewGuid();
            var a1 = new Employee(id1, "Joakim", "Karlsson", 20, 88,
                new List<Language>() {new Language() {Level = 1, EmployeeId = id1, LanguageName = "En"}});

            var id2 = Guid.NewGuid();
            var a2 = new Employee(id2, "Fredrik", "Adolfsson", 22, 89,
                new List<Language>() { new Language() { Level = 1, EmployeeId = id2, LanguageName = "Fr" } });

            var id3 = Guid.NewGuid();
            var a3 = new Employee(id3, "Volodymyr", "Oliinyk", 22, 100,
                new List<Language>() { new Language() { Level = 1, EmployeeId = id3, LanguageName = "Fr" } });
            
            return new List<Employee> {a1, a2, a3};
        }
    }
}
