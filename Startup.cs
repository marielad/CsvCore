using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TestASPNET.Services;
using Microsoft.EntityFrameworkCore;

namespace TestASPNET
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add a CORS Policy to allow "Everything":
            services.AddCors(o =>
            {
                o.AddPolicy("Everything", p =>
                {
                    p.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

                        // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(swagger =>
            {       
                swagger.SwaggerDoc(SwaggerConfiguration.DocName,
                                   new Info
                                   {
                                       Title = SwaggerConfiguration.DocInfoTitle,
                                       Version = SwaggerConfiguration.DocInfoVersion,
                                       Description = SwaggerConfiguration.DocInfoDescription
                                   }
                                    );
                // Set the comments path for the Swagger JSON and UI.
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, "TestASPNET.xml");
                // swagger.IncludeXmlComments(xmlPath);
                swagger.EnableAnnotations();
                swagger.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });


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
