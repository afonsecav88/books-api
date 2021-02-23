using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Interfaces;
using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Books
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
            services.AddControllers();
           //definiendo la cadena de conexión
            services.Configure<DatabaseStrings>(
           Configuration.GetSection(nameof(DatabaseStrings)));


            services.AddScoped<IBooks, CBooks>();

            //Definiendo DI
            services.AddSingleton<IDatabaseStrings>(x =>
            x.GetRequiredService<IOptions<DatabaseStrings>>().Value);

          
     
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

            //permitiendo acceso desde el frontend
            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
