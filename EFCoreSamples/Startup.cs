using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Microsoft.OpenApi.Models;
using EFCoreSamples.Infrastructure;
using EFCoreSamples.Infrastructure.ODataMappings;
using EFCoreSamples.Middlewares;
using System.Linq;

namespace EFCoreSamples
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
            services.AddDbContext<DatabaseContext>();
            services.AddControllers(config =>
            {
                foreach (var outputFormatter in config.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                foreach (var inputFormatter in config.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // 1. OData - Add o Data service
            services.AddOData();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "OData Samples",
                        Version = "v1"
                    });

                c.OperationFilter<SwaggerParameterFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData Samples");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // 2. OData - Enable Dependency Injection on current routes
                endpoints.EnableDependencyInjection(builder =>
                {
                    // 3. OData - Enable operations for mapped entities
                    builder.AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(IEdmModel), sp => EdmDtoConfig.GetEdmModel(app.ApplicationServices))
                    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new StringAsEnumResolver())
                    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new UnqualifiedCallAndEnumPrefixFreeResolver { EnableCaseInsensitive = true });
                });
            });
        }
    }
}
