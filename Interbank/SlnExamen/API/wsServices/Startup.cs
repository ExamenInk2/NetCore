using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SlnExamen.Domain;
using Swashbuckle.AspNetCore.Swagger;
using wsServices.Modelo;

namespace wsServices
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
            string BaseDatos = Environment.GetEnvironmentVariable("BaseDatos");
            if (string.IsNullOrEmpty(BaseDatos))
            {
                BaseDatos = Configuration.GetValue<string>("BaseDatos");
            }
            services.AddSingleton<IUnitOfWork>(option => new DapperUnitOfWork(BaseDatos));
            services.AddOptions();
            services.Configure<ParametroConfig>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Servicio Examen", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Servicio Examen");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
