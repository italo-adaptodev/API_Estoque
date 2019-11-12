using Estoque.Business.implementacoes;
using Estoque.Business.interfaces;
using Estoque.Context;
using Estoque.Models;
using Estoque.Repository;
using Estoque.Repository.implementacoes;
using Estoque.Repository.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;

namespace Estoque
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning(option => option.ReportApiVersions = true);
            services.AddSwaggerGen(c =>
            {
                var versionApp = _configuration["AppConfig:Version"];
                c.SwaggerDoc(versionApp,
                    new Info
                    {
                        Title = _configuration["AppConfig:AppName"],
                        Version = versionApp
                    });
            });

            var connectionString = _configuration["ConnectionString:SqlConnectionString"];
            services.AddDbContext<EstoqueContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITipoMaterialBusiness, TipoMaterialBusiness>();
            services.AddScoped<IMaterialBusiness, MaterialBusiness>();
            services.AddScoped<IEntradaEstoqueBusiness, EntradaEstoqueBusiness>();
            services.AddScoped<ISaidaEstoqueBusiness, SaidaEstoqueBusiness>();

            services.AddScoped(typeof(IGenericRepository<TipoMaterial>), typeof(GenericRepository<TipoMaterial>));
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IEntradaEstoqueRepository, EntradaEstoqueRepository>();
            services.AddScoped<ISaidaEstoqueRepository, SaidaEstoqueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{_configuration["AppConfig:Version"]}/swagger.json", _configuration["AppConfig:AppName"]);
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller}/{id?}");
            });
        }
    }
}
