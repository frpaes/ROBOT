using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Becomex.Robot.Application;
using Becomex.Robot.Application.Interfaces;
using Becomex.Robot.Application.Mapper;
using Becomex.Robot.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Becomex.Robot
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

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;

                    options.Conventions.Add(new VersionByNamespaceConvention());

                    options.AssumeDefaultVersionWhenUnspecified = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    options.SubstituteApiVersionInUrl = true;

                    options.AssumeDefaultVersionWhenUnspecified = true;
                });

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.RespectBrowserAcceptHeader = true;
                });

            services.AddResponseCompression(
                options =>
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>();
                });
            services.Configure<BrotliCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
            services.Configure<GzipCompressionProviderOptions>(
                options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });

            services.AddSwaggerGen(
                options =>
                {

                    using (var serviceProvider = services.BuildServiceProvider())
                    {
                        var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();


                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerDoc(description.GroupName, Info(description));
                        }
                    }

                });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(MapperDomainToViewModel).Assembly);
            services.AddDependenyInjectionConfiguration();
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                    options.RoutePrefix = string.Empty;
                });

            app.UseMvc();

        }


        static OpenApiInfo Info(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "Becomex Robot",
                Version = description.ApiVersion.ToString(),
                Description = "Robot" + (description.IsDeprecated ? " This API version has been deprecated." : string.Empty),
                Contact = new OpenApiContact { Name = "Fernando Paes", Email = "paes.frp@gmail.com" }
            };
        }
    }
}
