using Evaluacion.Despacho.BUSINESS.Interfaces;
using Evaluacion.Despacho.BUSINESS.Root;
using Evaluacion.Despacho.DATA.Interfaces;
using Evaluacion.Despacho.DATA.Model;
using Evaluacion.Despacho.DATA.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Despacho.API
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

            //services.AddDbContext<DespachoContext>(
            //    options => options.UseSqlServer(Configuration["ConnectionStrings:DespachoDB"]));

            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEstadoCivilService, EstadoCivilService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IPuestoService, PuestoService>();

            services.AddScoped<IBusinessEmpleado, BusinessEmpleado>();
            services.AddScoped<IBusinessEstadoCivil, BusinessEstadoCivil>();
            services.AddScoped<IBusinessGenero, BusinessGenero>();
            services.AddScoped<IBusinessPuesto, BusinessPuesto>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
}
