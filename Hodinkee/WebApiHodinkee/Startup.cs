using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services.Operations;

namespace WebApiHodinkee
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

            #region REGISTRO DE LOS SERVICIOS 
            services.AddSingleton(typeof(IArticle),
              F => BlogOperationsFactory.GetArticleOperations());

            services.AddSingleton(typeof(ITypesPost),
             F => BlogOperationsFactory.GetTypesPostOperations());

            #endregion

            services.AddSwaggerGen( doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title="Hodinkee API",
                    Version="v1"
                });
            });  


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(op =>
            {
                op.SwaggerEndpoint("/swagger/v1/swagger.json","Hodinkee API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
