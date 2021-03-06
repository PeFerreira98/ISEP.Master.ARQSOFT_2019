using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GorgeousFood.PointOfSale.API.Infrastructure;
using GorgeousFood.PointOfSale.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GorgeousFood.PointOfSale.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<GorgeousFoodContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MealDatabaseAzure")));
            //services.AddDbContext<GorgeousFoodMealContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MealDatabaseDocker")));

            services.AddTransient<IPointOfSaleRepository, PointOfSaleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(option => {
                option.AllowAnyOrigin();
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.WithMethods("GET", "POST", "PUT", "DELETE");
            });
        }
    }
}
